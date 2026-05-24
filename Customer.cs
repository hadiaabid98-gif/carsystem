using System;
using System.Data;
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

        // ADD button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox1.Focus();
        }

        // SAVE button
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

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

        // UPDATE button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter Customer ID to update.");
                return;
            }

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

        // DELETE button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter Customer ID to delete.");
                return;
            }

            bal.Delete(int.Parse(textBox1.Text));
            dataGridView1.DataSource = bal.GetAll();
        }

        // button1 = CLEAR
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        // button2 = SEARCH
        private void button2_Click(object sender, EventArgs e)
        {
            string keyword = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("Please enter a name to search.");
                return;
            }

            DataTable result = bal.Search(keyword);

            if (result.Rows.Count > 0)
                dataGridView1.DataSource = result;
            else
                MessageBox.Show("No record found.");
        }
    }
}