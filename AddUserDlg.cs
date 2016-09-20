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
    public partial class AddUserDlg : Form
    {
        string name = "";
        public AddUserDlg()
        {
            InitializeComponent();
        }

        private void cancelPressed_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okPressed_Click(object sender, EventArgs e)
        {
            name = this.paymentEntered.Text;
            this.Close();
        }

        public string returnName()
        {
            return name;
        }

    }
}
