using System;
using System.Data;
using System.Windows.Forms;
using CarSystem.BAL;
using CarSystem.Models;

namespace CarSystem
{
    public partial class Rental : Form
    {
        private RentalBAL bal = new RentalBAL();

        public Rental() { InitializeComponent(); }

        private void Rental_Load(object sender, EventArgs e)
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
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
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

            RentalModel r = new RentalModel
            {
                RentalID = int.Parse(textBox1.Text),
                CustomerName = textBox2.Text,
                CarName = textBox3.Text,
                Model = textBox4.Text,
                StartDate = dateTimePicker1.Value.Date,
                EndDate = dateTimePicker2.Value.Date,
                RentalStatus = textBox5.Text
            };
            bal.Save(r);
            dataGridView1.DataSource = bal.GetAll();
        }

        // UPDATE button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter Rental ID to update.");
                return;
            }

            RentalModel r = new RentalModel
            {
                RentalID = int.Parse(textBox1.Text),
                CustomerName = textBox2.Text,
                CarName = textBox3.Text,
                Model = textBox4.Text,
                StartDate = dateTimePicker1.Value.Date,
                EndDate = dateTimePicker2.Value.Date,
                RentalStatus = textBox5.Text
            };
            bal.Update(r);
            dataGridView1.DataSource = bal.GetAll();
        }

        // DELETE button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter Rental ID to delete.");
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
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }
    }
}