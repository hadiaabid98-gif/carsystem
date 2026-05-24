using System;
using System.Windows.Forms;

namespace CarSystem
{
    public partial class Main : Form
    {
        public Main() { InitializeComponent(); }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer cr = new Customer();
            cr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Car car = new Car();
            car.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Category cy = new Category();
            cy.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Rental rl = new Rental();
            rl.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Payment pt = new Payment();
            pt.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Maintenance me = new Maintenance();
            me.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Dashboard dd = new Dashboard();
            dd.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}