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
    public partial class PayUser : Form
    {
        public string _payer = "";
        public string _payee = "";
        public decimal _amount = 0;
        public bool pay_pressed = false;

        public PayUser(List<String> roomates)
        {
            InitializeComponent();
            payerChosen.Items.AddRange(roomates.ToArray());
            payeeChosen.Items.AddRange(roomates.ToArray());
        }


        private void paymentEntered_TextChanged(object sender, EventArgs e)
        {
            
            int decimalCount = itemModified.Text.Split('.').Length - 1;
            if (decimalCount > 1)
            {
                MessageBox.Show("Please enter a single decimal only");
                itemModified.Text = itemModified.Text.Remove(itemModified.Text.Length - 1);
            }
            else if ((System.Text.RegularExpressions.Regex.IsMatch(itemModified.Text, "[^0-9]")
                && !(decimalCount == 1)) || itemModified.Text.Contains("-"))
            {
                MessageBox.Show("Please enter only numbers.");
                itemModified.Text = itemModified.Text.Remove(itemModified.Text.Length - 1);
            }

            if (!itemModified.Text.Equals(String.Empty))
            {
                _amount = Convert.ToDecimal(itemModified.Text);
            }
        }

        private void payPressed_Click(object sender, EventArgs e)
        {
            pay_pressed = true;
            this.Close();
        }

        private void cancelPressed_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void payerChosen_SelectedIndexChanged(object sender, EventArgs e)
        {
            _payer = payerChosen.Text;

        }

        private void payeeChosen_SelectedIndexChanged(object sender, EventArgs e)
        {
            _payee = payeeChosen.Text;
        }
    }
}
