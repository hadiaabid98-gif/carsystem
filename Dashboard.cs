using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Calling display methods
            display1();
            display2();
            display3();
        }
        // Method for displaying total customers
        private void display1()
        {
            // Database connection
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            // Open connection
            con.Open();
            // SQL query to count customers
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM customers", con);
            // Store count in variable
            Int32 count = Convert.ToInt32(command.ExecuteScalar());
            // Check if count is greater than 0
            if (count > 0)
            {
                // Display count in label
                lblCount1.Text = Convert.ToString(count.ToString());
            }
            else
            {
                lblCount1.Text = "";
            }
            // Close connection
            con.Close();
        }
        // Method for displaying total cars
        private void display2()
        {
            // Database connection
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            // Open connection
            con.Open();
            // SQL query to count cars
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM cars", con);
            // Store count in variable
            Int32 count = Convert.ToInt32(command.ExecuteScalar());
            // Check if count is greater than 0
            if (count > 0)
            {
                // Display count in label
                lblCount2.Text = Convert.ToString(count.ToString());
            }
            else
            {
                lblCount2.Text = "";
            }
            // Close connection
            con.Close();
        }
        // Method for displaying total categories
        private void display3()
        {
            // Database connection
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            // Open connection
            con.Open();
            // SQL query to count categories
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM categories", con);
            // Store count in variable
            Int32 count = Convert.ToInt32(command.ExecuteScalar());
            // Check if count is greater than 0 
            if (count > 0)
            {
                // Display count in label
                lblCount3.Text = Convert.ToString(count.ToString());
            }
            else
            {
                lblCount3.Text = "";
            }
            // Close connection
            con.Close();
        }

    }
}
