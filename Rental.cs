using System;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bal.GetAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bal.Delete(int.Parse(textBox1.Text));
            dataGridView1.DataSource = bal.GetAll();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = "";
            textBox4.Text = ""; textBox5.Text = "";
        }

        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }
    }
}