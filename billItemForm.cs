using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroceryForm
{
    public partial class billItemForm : Form
    {
        public string _biller = "";
        public string _item = "";
        public string _description = "";
        public decimal _cost = 0;
        
        public bool Bill_pressed = false;

        public billItemForm(List<String> roomateNames)
        { 
            InitializeComponent();
            comboBox1.Items.AddRange(roomateNames.ToArray());
            checkedListBox1.Items.AddRange(roomateNames.ToArray());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _biller = comboBox1.Text;
        }

        public List<string> sharingMates()
        {
            List<string> shared_list = new List<string>();
            foreach(string item in checkedListBox1.CheckedItems)
            {
                shared_list.Add(item);
            }

            return shared_list;
        }

        private void itemModified_TextChanged(object sender, EventArgs e)
        {
            _item = itemModified.Text;
        }

        private void descModified_TextChanged(object sender, EventArgs e)
        {
            _description = descModified.Text;
        }

        private void costModified_TextChanged(object sender, EventArgs e)
        {
            int decimalCount = costModified.Text.Split('.').Length - 1;
            if (decimalCount > 1)
            {
                MessageBox.Show("Please enter a single decimal only");
                costModified.Text = costModified.Text.Remove(costModified.Text.Length - 1);
            }
            else if ((System.Text.RegularExpressions.Regex.IsMatch(costModified.Text, "[^0-9]")
                && !(decimalCount == 1)) || costModified.Text.Contains("-"))
            {
                MessageBox.Show("Please enter only numbers.");
                costModified.Text = costModified.Text.Remove(costModified.Text.Length - 1);
            }

            if (!costModified.Text.Equals(String.Empty))
            {
                _cost = Convert.ToDecimal(costModified.Text);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (_biller.Equals(String.Empty)
                || _cost.Equals(String.Empty)
                || _description.Equals(String.Empty)
                || checkedListBox1.CheckedItems.Count == 0
                )
            {
                MessageBox.Show("Please fill ALL fields with valid information");
            }
            else
            {
                Bill_pressed = true;
                this.Close();
            }
        }
    }
}
