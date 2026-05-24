using System;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            CategoryModel c = new CategoryModel
            {
                CategoryID = int.Parse(textBox1.Text),
                CarName = textBox2.Text,
                CategoryName = textBox3.Text
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
            CategoryModel c = new CategoryModel
            {
                CategoryID = int.Parse(textBox1.Text),
                CarName = textBox2.Text,
                CategoryName = textBox3.Text
            };
            bal.Update(c);
            dataGridView1.DataSource = bal.GetAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bal.Delete(int.Parse(textBox1.Text));
            dataGridView1.DataSource = bal.GetAll();
        }
    }
}