using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using CarSystem.DAL;

namespace CarSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard() { InitializeComponent(); }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            display1(); display2(); display3();
        }

        private void display1()
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                int count = (int)new SqlCommand("SELECT COUNT(*) FROM customers", con).ExecuteScalar();
                lblCount1.Text = count > 0 ? count.ToString() : "";
            }
        }

        private void display2()
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                int count = (int)new SqlCommand("SELECT COUNT(*) FROM cars", con).ExecuteScalar();
                lblCount2.Text = count > 0 ? count.ToString() : "";
            }
        }

        private void display3()
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                int count = (int)new SqlCommand("SELECT COUNT(*) FROM categories", con).ExecuteScalar();
                lblCount3.Text = count > 0 ? count.ToString() : "";
            }
        }
    }
}