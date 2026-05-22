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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into customers values(@customerid,@customername,@email,@phone,@address)", con);
            cnn.Parameters.AddWithValue("@customerid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@customerName", textBox2.Text);
            cnn.Parameters.AddWithValue("@email", textBox3.Text);
            cnn.Parameters.AddWithValue("@phone", textBox4.Text);
            cnn.Parameters.AddWithValue("@address", textBox5.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved Successfully");

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from customers", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("update customers set customername=@customername,email=@email,phone=@phone,address=@address where customerid=@customerid", con);
            cnn.Parameters.AddWithValue("@customerid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@customerName", textBox2.Text);
            cnn.Parameters.AddWithValue("@email", textBox3.Text);
            cnn.Parameters.AddWithValue("@phone", textBox4.Text);
            cnn.Parameters.AddWithValue("@address", textBox5.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Update Successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("delete from customers where customerid=@customerid", con);
            cnn.Parameters.AddWithValue("@customerid", int.Parse(textBox1.Text));
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Delete Successfully");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();

            SqlCommand cmd = new SqlCommand(
                "SELECT * FROM Customers WHERE CustomerID=@CustomerID OR CustomerName=@CustomerName OR Phone=@Phone",
                con);

            cmd.Parameters.AddWithValue("@CustomerID", textBox1.Text);
            cmd.Parameters.AddWithValue("@CustomerName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Phone", textBox4.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            con.Close();

            MessageBox.Show("Record Found Successfully");
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from customers", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
