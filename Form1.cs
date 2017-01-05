using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GroceryForm
{
    public partial class Form1 : Form
    {
        Dictionary<String, User> Roomates = new Dictionary<String, User>();
        List<LogItem> Receipt = new List<LogItem>();


        class cacheItem
        {
            public Dictionary<String, User> _roomateinfo;
            public Dictionary<string, decimal> _prevBalance;
            public List<LogItem> _receiptInfo;

            public cacheItem(Dictionary<String, User> roomateinfo, List<LogItem> receiptInfo)
            {
                _roomateinfo = roomateinfo;
                _receiptInfo = receiptInfo;
                if(_roomateinfo.Count > 0)
                {
                    _prevBalance = new Dictionary<string, decimal>(roomateinfo.ElementAt(0).Value.balance);
                }
            }


        };

        Stack<cacheItem> undoCache = new Stack<cacheItem>();


        bool inside = false;

        public Form1()
        {
            InitializeComponent();
            paymentChart.ReadOnly = true;
            init_on_open();
            updateDataGrid();
            if (prog_occupied())
            {
                MessageBox.Show("Program in Use by another roomate, please try again later");
                this.Close();
            }
            else {
                inside = true;
                occupy_prog("Yes");
            }
        }
        private void occupy_prog(string val)
        {
            try
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter("bin\\occupied.dat");
                file.WriteLine(val);
                file.Close();
            }
            catch
            {
                return;
            }
        }
        private bool prog_occupied()
        {
            try
            {
                System.IO.StreamReader fs = new System.IO.StreamReader("bin\\occupied.dat");
                string val = fs.ReadLine();
                fs.Close();
                return val == "Yes";
            }
            catch
            {
                return false;
            }
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            save_on_closing();
            if (inside)
            {
                occupy_prog("No");
            }
        }

        private void init_on_open()
        {
            if (File.Exists("bin\\data.dat"))
            {
                System.IO.StreamReader fs = new System.IO.StreamReader("bin\\data.dat");
                int roomateCount = int.Parse(fs.ReadLine());
                for(int i = 0; i < roomateCount; ++i)
                {
                    string name = fs.ReadLine();

                    paymentChart.Rows.Add();
                    paymentChart.Rows[i].Cells[0].Value = name;
                    paymentChart.Columns.Add(name,
                        "Owes " + name);

                    int numRoomates = int.Parse(fs.ReadLine());
                    Dictionary<string, decimal> roomateBalances = 
                        new Dictionary<string, decimal>();
                    for(int j = 0; j < numRoomates; ++j)
                    {
                        string roomateName = fs.ReadLine();
                        decimal roomateBalance = decimal.Parse(fs.ReadLine());
                        roomateBalances.Add(roomateName, roomateBalance);
                    }

                    Roomates.Add(name, new User(name, roomateBalances));
                }

                int logItemCount = int.Parse(fs.ReadLine());
                for(int i = 0; i < logItemCount; ++i)
                {
                    string date = fs.ReadLine();
                    string item = fs.ReadLine();
                    string descr = fs.ReadLine();
                    decimal cost = decimal.Parse(fs.ReadLine());
                    int splitWithCount = int.Parse(fs.ReadLine());
                    List<string> splitsWithMates = new List<String>();
                    for(int j = 0; j < splitWithCount; ++j)
                    {
                        splitsWithMates.Add(fs.ReadLine());
                    }

                    Receipt.Add(new LogItem(date, item, descr, cost, splitsWithMates));
                }

                fs.Close();
            }

        }

        private void save_on_closing()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("bin\\data.dat");
            List<string> saveData = new List<string>();

            saveData.Add(Roomates.Count().ToString());
            foreach(KeyValuePair<String, User> Roomate in Roomates)
            {
                saveData.Add(Roomate.Value.getName());
                saveData.Add(Roomate.Value.returnBalance().Count().ToString());
                foreach(KeyValuePair<String, Decimal> indvBalance in 
                    Roomate.Value.returnBalance())
                {
                    saveData.Add(indvBalance.Key);
                    saveData.Add(indvBalance.Value.ToString());
                }
            }

            saveData.Add(Receipt.Count.ToString());

            foreach (LogItem item in Receipt)
            {
                saveData.Add(item._date);
                saveData.Add(item._item);
                saveData.Add(item._decription);
                saveData.Add(item._cost.ToString());
                saveData.Add(item._splitWith.Count.ToString());
                saveData.AddRange(item._splitWith);
            }

            foreach (string line in saveData)
            {
                file.WriteLine(line);
            }

            file.Close();
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            AddUserDlg addUserDlgObj = new AddUserDlg();
            addUserDlgObj.ShowDialog();
            if (!addUserDlgObj.returnName().Equals(String.Empty))
            {
                undoCache.Push(new cacheItem(new Dictionary<String, User>(Roomates), 
                    new List<LogItem>(Receipt)));
                List<String> roomateNames = getRoomateNames();
                roomateNames.Add(addUserDlgObj.returnName());

                User newRoomate = new User(addUserDlgObj.returnName(), roomateNames);

                foreach(KeyValuePair<String, User> mate in Roomates)
                {
                    mate.Value.addRoomate(newRoomate.getName());
                }

                Roomates.Add(newRoomate.getName(), newRoomate);
          

                paymentChart.Rows.Add();
                paymentChart.Rows[Roomates.Count - 1].Cells[0].Value = newRoomate.getName();
                paymentChart.Columns.Add(newRoomate.getName(),
                    "Owes " + newRoomate.getName());
                paymentChart.AutoResizeColumns();
                paymentChart.AutoResizeRows();
            }

            updateDataGrid();

        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            List<string> roomateNames = getRoomateNames();
            PayUser PayUserDlg = new PayUser(roomateNames);
            PayUserDlg.ShowDialog();

            if (PayUserDlg.pay_pressed)
            {
                undoCache.Push(new cacheItem(new Dictionary<String, User>(Roomates),
                    new List<LogItem>(Receipt)));
                changeBalance(PayUserDlg._payer, PayUserDlg._payee, PayUserDlg._amount);
            }

            updateDataGrid();
        }

        private void updateDataGrid()
        {
           for(int i = 0; i < paymentChart.Rows.Count - 1; ++i)
            {
                for (int j = 1; j < paymentChart.Columns.Count; ++j)
                {
                    try
                    {
                        
                        paymentChart.Rows[i].Cells[j].Value =
                            Roomates[paymentChart.Rows[i].Cells[0].Value.ToString()].
                            getIndvBalance(paymentChart.Columns[j].Name).ToString();
                    }
                    catch
                    {
                        paymentChart.Rows[i].Cells[j].Value = "0";
                    }

                    string value = paymentChart.Rows[i].Cells[j].Value.ToString();
                    if(value[0] == '-')
                    {
                        paymentChart.Rows[i].Cells[j].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        paymentChart.Rows[i].Cells[j].Style.ForeColor = Color.Green;
                    }
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            billItemForm billItemDlg = new billItemForm(getRoomateNames());
            billItemDlg.ShowDialog();

            if (billItemDlg.Bill_pressed)
            {
                undoCache.Push(new cacheItem(new Dictionary<String, User>(Roomates),
                    new List<LogItem>(Receipt)));
                foreach (string roomate in billItemDlg.sharingMates())
                {
                    decimal sharedItemCost =
                        billItemDlg._cost / billItemDlg.sharingMates().Count;
                    sharedItemCost *= 100;
                    sharedItemCost = Decimal.Round(sharedItemCost);
                    sharedItemCost /= 100;
                    changeBalance(billItemDlg._biller, roomate,
                        sharedItemCost);
                }

                Receipt.Add(new LogItem(System.DateTime.Now.ToString("yyyy.MM.dd"),
                    billItemDlg._item,
                    billItemDlg._description,
                    billItemDlg._cost,
                    billItemDlg.sharingMates()));
            }

            updateDataGrid();
        }

        private List<string> getRoomateNames()
        {
            List<String> roomateNames = new List<String>();
            foreach (KeyValuePair<String, User> mate in Roomates)
            {
                roomateNames.Add(mate.Value.getName());
            }

            return roomateNames;
        }

        private void changeBalance(string payer, string payee, decimal amount)
        {
            Roomates[payer].changeBalance(payee, amount);
            Roomates[payee].changeBalance(payer, 0 - amount);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("Receipt.txt");
            foreach (LogItem Item in Receipt)
            {
                string line = "";
                line += (Item._date.ToString() + "|");
                line += (Item._item + "|");
                line += (Item._decription + "|");
                line += (Item._cost.ToString() + "|");
                foreach(string mate in Item._splitWith)
                {
                    line += mate + " ";
                }

                file.WriteLine(line);
            }

            file.Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            int NumRoomates = Roomates.Count;
            cacheItem prevState = undoCache.Pop();
            Roomates = prevState._roomateinfo;
            Receipt = prevState._receiptInfo;

            if (NumRoomates > Roomates.Count)
            {
                paymentChart.Rows.RemoveAt(NumRoomates - 1);
                paymentChart.Columns.RemoveAt(NumRoomates - 1);
            }

            if(Roomates.Count > 0)
            {
                foreach( KeyValuePair<String, User> person in Roomates)
                {
                    person.Value.balance = prevState._prevBalance;
                }
            }

            updateDataGrid();
        }
    }
}
