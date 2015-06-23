using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankClient.MainService;

namespace BankClient
{
    public partial class TransferForm : Form
    {
        private List<Client> clientsToTransfer;
        private Client clientWhoTransfers;
        public decimal money;
        public string accToTransfer;
        //private string transferTo;
        //private 
        public TransferForm(List<Client> clients, Client client)
        {
            InitializeComponent();
            clientWhoTransfers = client;
            clientsToTransfer = clients;

            clientsToTransfer
                .Remove(clientWhoTransfers);
            
            //clientsToTransfer = clientsToTransfer
            //    .Remove();
            label1.Text = String.Format("{0}, {1} {2}", clientWhoTransfers.Balance.ToString(),
                clientWhoTransfers.FirstName, clientWhoTransfers.SecondName);
            InitComboBox();
        }

        public void InitComboBox()
        {
            foreach (var item in clientsToTransfer)
            {
                comboBox1.Items.Add(String.Format("{0}, {1} {2}", item.Balance.ToString(), item.FirstName,
                    item.SecondName));
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (clientWhoTransfers.Balance >= numericUpDown1.Value)
            {
                this.money = numericUpDown1.Value;
                this.accToTransfer = clientsToTransfer[comboBox1.SelectedIndex].AccountNumber;
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Недостаточно средств для перевода");

        }
    }
}
