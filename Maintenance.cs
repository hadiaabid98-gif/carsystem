using System;
using System.Windows.Forms;
using CarSystem.BAL;
using CarSystem.Models;

namespace CarSystem
{
    public partial class Maintenance : Form
    {
        private MaintenanceBAL bal = new MaintenanceBAL();

        public Maintenance() { InitializeComponent(); }

        private void Maintenance_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bal.GetAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MaintenanceModel m = new MaintenanceModel
            {
                MaintenanceID = int.Parse(textBox1.Text),
                CarName = textBox2.Text,
                Model = textBox3.Text,
                Service = textBox4.Text,
                Cost = int.Parse(textBox5.Text)
            };
            bal.Save(m);
            dataGridView1.DataSource = bal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bal.GetAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MaintenanceModel m = new MaintenanceModel
            {
                MaintenanceID = int.Parse(textBox1.Text),
                CarName = textBox2.Text,
                Model = textBox3.Text,
                Service = textBox4.Text,
                Cost = int.Parse(textBox5.Text)
            };
            bal.Update(m);
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
    }
}