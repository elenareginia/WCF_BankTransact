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
//using BankClient.ServiceReference1;


namespace BankClient
{
    public partial class Form1 : Form
    {
        private MainServiceClient handler;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.MultiSelect = false;
        }

        public void InitGrid()
        {
            if (handler.GetAllClients() != null)
            {
                dataGridView1.DataSource = handler.GetAllClients();
                dataGridView1.Columns["Id"].Visible = false;
            }
        }

        //seed
        private void seedSomePeopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (handler.GetAllClients() == null)
            {
                handler.Seed();
                InitGrid();
            }
            else MessageBox.Show("No need to seed anymore");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            handler = new MainServiceClient();
            if (handler.GetAllClients() != null)
            {
                InitGrid();
            }          
        }

        //add money
        private void button1_Click(object sender, EventArgs e)
        {
            int selectedId = dataGridView1.SelectedRows[0].Index;
            var clients = handler.GetAllClients();
            var chosenClient = clients[selectedId];
            BalanceForm bf =
                new BalanceForm(String.Format("{0}, {1} {2}", chosenClient.AccountNumber, chosenClient.FirstName,
                    chosenClient.SecondName));
            if (bf.ShowDialog() == DialogResult.OK)
            {
                if (handler.AddMoneyToAcc(chosenClient.AccountNumber, bf.money))
                {
                    MessageBox.Show("Operation completeed succefully");

                }
                else MessageBox.Show("Ooops, something goes wrong");
                InitGrid();
            }
        }

        //remove money
        private void button2_Click(object sender, EventArgs e)
        {
            int selectedId = dataGridView1.SelectedRows[0].Index;
            var clients = handler.GetAllClients();
            var chosenClient = clients[selectedId];
            BalanceForm bf =
                new BalanceForm(String.Format("{0}, {1} {2}", chosenClient.AccountNumber, chosenClient.FirstName,
                    chosenClient.SecondName));
            if (bf.ShowDialog() == DialogResult.OK)
            {
                if (handler.RemoveMoneyFromAcc(chosenClient.AccountNumber, bf.money))
                {
                    MessageBox.Show("Operation completeed succefully");

                }
                else MessageBox.Show("Ooops, something goes wrong");
                InitGrid();
            }
        }

        //transfer
        private void button3_Click(object sender, EventArgs e)
        {
            int selectedId = dataGridView1.SelectedRows[0].Index;
            List<Client> clients = handler.GetAllClients().ToList();
            var chosenClient = clients[selectedId];
            TransferForm tf =
                new TransferForm(clients,chosenClient);
            if (tf.ShowDialog() == DialogResult.OK)
            {
                if (handler.Transfer(chosenClient.AccountNumber, tf.accToTransfer, tf.money))
                {
                    MessageBox.Show("Transfer succed");
                    InitGrid();
                }
                else MessageBox.Show("Transfer error");
            }
        }
    }
}
