using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankClient
{
    public partial class BalanceForm : Form
    {
        public decimal money;
        public BalanceForm(string title)
        {
            InitializeComponent();
            label1.Text = title;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            money = numericUpDown1.Value;
            this.DialogResult = DialogResult.OK;
        }
    }
}
