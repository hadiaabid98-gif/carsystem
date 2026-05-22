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
    public partial class Car : Form
    {
        public Car()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Creating connection with SQL server
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            // Opening connection 
            con.Open();
            // Insert query for saving data into cars table
            SqlCommand cnn = new SqlCommand("insert into cars values(@carid,@carname,@model,@platenumber,@color,@dailyrate,@status )", con);
            // Passing values from textboxes to parameters
            cnn.Parameters.AddWithValue("@carid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@carName", textBox2.Text);
            cnn.Parameters.AddWithValue("@model", textBox3.Text);
            cnn.Parameters.AddWithValue("@platenumber", textBox4.Text);
            cnn.Parameters.AddWithValue("@color", textBox5.Text);
            cnn.Parameters.AddWithValue("@dailyrate", int.Parse(textBox6.Text));
            cnn.Parameters.AddWithValue("@status", textBox7.Text);
            // Executing query
            cnn.ExecuteNonQuery();
            // Closing connection
            con.Close();
            // Success message
            MessageBox.Show("Record Saved Successfully");

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Database connection
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            // Open connection
            con.Open();
            // Select all records from cars table
            SqlCommand cnn = new SqlCommand("select * from cars", con);
            // DataAdapter object
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            // DataTable object
            DataTable table = new DataTable();
            // Filling table with data
            da.Fill(table);
            // Showing data in DataGridView
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Database connection
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            // Open connection
            con.Open();
            // Update query 
            SqlCommand cnn = new SqlCommand("update cars set carname=@carname,model=@model,platenumber=@platenumber,color=@color,dailyrate=@dailyrate,status=@status where carid=@carid", con);
            // Passing updated values
            cnn.Parameters.AddWithValue("@carid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@carName", textBox2.Text);
            cnn.Parameters.AddWithValue("@model", textBox3.Text);
            cnn.Parameters.AddWithValue("@platenumber", textBox4.Text);
            cnn.Parameters.AddWithValue("@color", textBox5.Text);
            cnn.Parameters.AddWithValue("@dailyrate", int.Parse(textBox6.Text));
            cnn.Parameters.AddWithValue("@status", textBox7.Text);
            // Execute update query
            cnn.ExecuteNonQuery();
            // Close connection
            con.Close();
            // Success message
            MessageBox.Show("Record Updated Successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Database connection
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            // Open connection
            con.Open();
            // Delete query
            SqlCommand cnn = new SqlCommand("delete from cars where carid=@carid", con);
            // Passing car id
            cnn.Parameters.AddWithValue("@carid", int.Parse(textBox1.Text));
            // Execute delete query
            cnn.ExecuteNonQuery();
            // Close connection
            con.Close();
            // Success message
            MessageBox.Show("Record Delete Successfully");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clearing all textboxes
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void Car_Load(object sender, EventArgs e)
        {

            // Database connection
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            // Open connection
            con.Open();
            // Select all records from cars table
            SqlCommand cnn = new SqlCommand("select * from cars", con);
            // DataAdapter object
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            // DataTable object
            DataTable table = new DataTable();
            // Filling table with data
            da.Fill(table);
            // Showing data in DataGridView
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=CarSystemDB;Integrated Security=True;TrustServerCertificate=True");
            con.Open();

            SqlCommand cmd = new SqlCommand(
                @"SELECT * FROM Cars 
          WHERE CarID=@CarID 
          OR CarName=@CarName 
          OR Model=@Model 
          OR PlateNumber=@PlateNumber 
          OR Color=@Color 
          OR Status=@Status",
                con);

            cmd.Parameters.AddWithValue("@CarID", textBox1.Text);
            cmd.Parameters.AddWithValue("@CarName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Model", textBox3.Text);
            cmd.Parameters.AddWithValue("@PlateNumber", textBox4.Text);
            cmd.Parameters.AddWithValue("@Color", textBox5.Text);
            cmd.Parameters.AddWithValue("@Status", textBox6.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            con.Close();
        }
    }
}
