using System;
using System.Data;
using System.Windows.Forms;
using CarSystem.BAL;
using CarSystem.Models;

namespace CarSystem
{
    public partial class Car : Form
    {
        private CarBAL bal = new CarBAL();

        public Car() { InitializeComponent(); }

        private void Car_Load(object sender, EventArgs e)
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
            textBox6.Text = "";
            textBox7.Text = "";
            textBox1.Focus();
        }

        // SAVE button: naya car record database mein save karo
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            CarModel car = new CarModel
            {
                CarID = int.Parse(textBox1.Text),
                CarName = textBox2.Text,
                Model = textBox3.Text,
                PlateNumber = textBox4.Text,
                Color = textBox5.Text,
                DailyRate = int.Parse(textBox6.Text),
                Status = textBox7.Text
            };
            bal.Save(car);
            dataGridView1.DataSource = bal.GetAll();
        }

        // UPDATE button: existing record update karo
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter Car ID to update.");
                return;
            }

            CarModel car = new CarModel
            {
                CarID = int.Parse(textBox1.Text),
                CarName = textBox2.Text,
                Model = textBox3.Text,
                PlateNumber = textBox4.Text,
                Color = textBox5.Text,
                DailyRate = int.Parse(textBox6.Text),
                Status = textBox7.Text
            };
            bal.Update(car);
            dataGridView1.DataSource = bal.GetAll();
        }

        // DELETE button: record delete karo
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter Car ID to delete.");
                return;
            }

            bal.Delete(int.Parse(textBox1.Text));
            dataGridView1.DataSource = bal.GetAll();
        }

        // CLEAR button
        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        // SEARCH button
        private void button1_Click(object sender, EventArgs e)
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