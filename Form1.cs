using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CarSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Create database connection
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            // Open database connection
            con.Open();
            // Store username entered by user
            string username = txtUsername.Text;
            // Store password entered by user
            string password = txtPassword.Text;
            // Create SQL query for login checking
            SqlCommand cmd = new SqlCommand("select Username,Password from logintab where Username='" + txtUsername.Text + "'and Password='" + txtPassword.Text + "'", con);
            // Create DataAdapter object to fetch data
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // Create DataTable to store fetched data
            DataTable dt = new DataTable();
            // Fill DataTable with database data
            da.Fill(dt);
            // Check Wheather user exists or not
            if (dt.Rows.Count > 0)
            {
                Main mn = new Main();
                mn.Show();
                
            }
            else
            {
                // Show error message if login fails
                MessageBox.Show("Invalid Login");
            }
            // Close database connection
            con.Close();

        }
    }
    
}
