using System;
using System.Data;
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

        // ADD button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
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

        // UPDATE button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter Payment ID to update.");
                return;
            }

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

        // DELETE button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter Payment ID to delete.");
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
        }
    }
}