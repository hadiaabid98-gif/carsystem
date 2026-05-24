using System;
using System.Windows.Forms;
using CarSystem.BAL;
using CarSystem.Models;

namespace CarSystem
{
    public partial class Customer : Form
    {
        private CustomerBAL bal = new CustomerBAL();

        public Customer() { InitializeComponent(); }

        private void Customer_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bal.GetAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CustomerModel c = new CustomerModel
            {
                CustomerID = int.Parse(textBox1.Text),
                CustomerName = textBox2.Text,
                Email = textBox3.Text,
                Phone = textBox4.Text,
                Address = textBox5.Text
            };
            bal.Save(c);
            dataGridView1.DataSource = bal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bal.GetAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CustomerModel c = new CustomerModel
            {
                CustomerID = int.Parse(textBox1.Text),
                CustomerName = textBox2.Text,
                Email = textBox3.Text,
                Phone = textBox4.Text,
                Address = textBox5.Text
            };
            bal.Update(c);
            dataGridView1.DataSource = bal.GetAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bal.Delete(int.Parse(textBox1.Text));
            dataGridView1.DataSource = bal.GetAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = "";
            textBox4.Text = ""; textBox5.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bal.GetAll();
        }
    }
}