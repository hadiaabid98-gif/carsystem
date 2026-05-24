using System;
using System.Windows.Forms;
using CarSystem.BAL;
using CarSystem.Models;

namespace CarSystem
{
    public partial class Payment : Form
    {
        private PaymentBAL bal = new PaymentBAL();

        public Payment() { InitializeComponent(); }

        private void Payment_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bal.GetAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PaymentModel p = new PaymentModel
            {
                PaymentID = int.Parse(textBox1.Text),
                CustomerName = textBox2.Text,
                Amount = int.Parse(textBox3.Text),
                PaymentMethod = textBox4.Text
            };
            bal.Save(p);
            dataGridView1.DataSource = bal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bal.GetAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            PaymentModel p = new PaymentModel
            {
                PaymentID = int.Parse(textBox1.Text),
                CustomerName = textBox2.Text,
                Amount = int.Parse(textBox3.Text),
                PaymentMethod = textBox4.Text
            };
            bal.Update(p);
            dataGridView1.DataSource = bal.GetAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bal.Delete(int.Parse(textBox1.Text));
            dataGridView1.DataSource = bal.GetAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";
        }
    }
}