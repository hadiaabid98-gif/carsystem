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
    public partial class Maintenance : Form
    {
        public Maintenance()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into maintenance values(@maintenanceid,@carname,@model,@service,@cost)", con);
            cnn.Parameters.AddWithValue("@maintenanceid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@carname", textBox2.Text);
            cnn.Parameters.AddWithValue("@model", textBox3.Text);
            cnn.Parameters.AddWithValue("@service", textBox4.Text);
            cnn.Parameters.AddWithValue("@cost", int.Parse(textBox5.Text));
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved Successfully");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from maintenance", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("Update maintenance set carname=@carname,model=@model,service=@service,cost=@cost where maintenanceid=@maintenanceid", con);
            cnn.Parameters.AddWithValue("@maintenanceid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@carname", textBox2.Text);
            cnn.Parameters.AddWithValue("@model", textBox3.Text);
            cnn.Parameters.AddWithValue("@service", textBox4.Text);
            cnn.Parameters.AddWithValue("@cost", int.Parse(textBox5.Text));
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("delete from maintenance where maintenanceid=@maintenanceid", con);
            cnn.Parameters.AddWithValue("@maintenanceid", int.Parse(textBox1.Text));
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Successfully");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox5.Text = "";
        }

        private void Maintenance_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from maintenance", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
