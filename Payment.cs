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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into payments values(@paymentid,@customername,@amount,@paymentmethod)", con);
            cnn.Parameters.AddWithValue("@paymentid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@customerName", textBox2.Text);
            cnn.Parameters.AddWithValue("@amount", int.Parse(textBox3.Text));
            cnn.Parameters.AddWithValue("@paymentmethod", textBox4.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved Successfully");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from payments", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("update payments set customername=@customername,amount=@amount,paymentmethod=@paymentmethod where paymentid=@paymentid", con);
            cnn.Parameters.AddWithValue("@paymentid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@customerName", textBox2.Text);
            cnn.Parameters.AddWithValue("@amount", int.Parse(textBox3.Text));
            cnn.Parameters.AddWithValue("@paymentmethod", textBox4.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("delete from payments where paymentid=@paymentid", con);
            cnn.Parameters.AddWithValue("@paymentid", int.Parse(textBox1.Text));
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
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from payments", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
