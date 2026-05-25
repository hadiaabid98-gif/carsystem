using System;
using System.Data;
using System.Windows.Forms;
using CarSystem.BAL;
using CarSystem.Models;

namespace CarSystem
{
    public partial class Category : Form
    {
        private CategoryBAL bal = new CategoryBAL();

        public Category() { InitializeComponent(); }

        private void Category_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bal.GetAll();
        }


        // SAVE button
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            CategoryModel c = new CategoryModel
            {
                CategoryID = int.Parse(textBox1.Text),
                CarName = textBox2.Text,
                CategoryName = textBox3.Text
            };
            bal.Save(c);
            dataGridView1.DataSource = bal.GetAll();
        }

        // UPDATE button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter Category ID to update.");
                return;
            }

            CategoryModel c = new CategoryModel
            {
                CategoryID = int.Parse(textBox1.Text),
                CarName = textBox2.Text,
                CategoryName = textBox3.Text
            };
            bal.Update(c);
            dataGridView1.DataSource = bal.GetAll();
        }

        // DELETE button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter Category ID to delete.");
                return;
            }

            bal.Delete(int.Parse(textBox1.Text));
            dataGridView1.DataSource = bal.GetAll();
        }
    }
}