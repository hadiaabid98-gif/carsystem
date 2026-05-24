using System;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bal.GetAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bal.Delete(int.Parse(textBox1.Text));
            dataGridView1.DataSource = bal.GetAll();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = "";
            textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = ""; textBox7.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bal.GetAll();
        }
    }
}