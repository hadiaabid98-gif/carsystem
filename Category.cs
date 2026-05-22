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
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into categories values(@categoryid,@carname,@categoryname)", con);
            cnn.Parameters.AddWithValue("@categoryid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@carname", textBox2.Text);
            cnn.Parameters.AddWithValue("@categoryname", textBox3.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved Successfully");

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from categories", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("update categories set carname=@carname,categoryname=@categoryname where categoryid=@categoryid", con);
            cnn.Parameters.AddWithValue("@categoryid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@carname", textBox2.Text);
            cnn.Parameters.AddWithValue("@categoryname", textBox3.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("delete from categories where categoryid=@categoryid", con);
            cnn.Parameters.AddWithValue("@categoryid", int.Parse(textBox1.Text));
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Successfully");
        }

        private void Category_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from categories", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
