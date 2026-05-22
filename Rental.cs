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
    public partial class Rental : Form
    {
        public Rental()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into rentals values(@rentalid,@customername,@carname,@model,@startdate,@enddate,@rentalstatus )", con);
            cnn.Parameters.AddWithValue("@rentalid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@customername", textBox2.Text);
            cnn.Parameters.AddWithValue("@carname", textBox3.Text);
            cnn.Parameters.AddWithValue("@model", textBox4.Text);
            cnn.Parameters.AddWithValue("@startdate", dateTimePicker1.Value.Date);
            cnn.Parameters.AddWithValue("@enddate", dateTimePicker2.Value.Date);
            cnn.Parameters.AddWithValue("@rentalstatus", textBox5.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved Successfully");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from rentals", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("update rentals set customername=@customername,carname=@carname,model=@model,startdate=@startdate,enddate=@enddate,rentalstatus=@rentalstatus where rentalid=@rentalid", con);
            cnn.Parameters.AddWithValue("@rentalid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@customername", textBox2.Text);
            cnn.Parameters.AddWithValue("@carname", textBox3.Text);
            cnn.Parameters.AddWithValue("@model", textBox4.Text);
            cnn.Parameters.AddWithValue("@startdate", dateTimePicker1.Value.Date);
            cnn.Parameters.AddWithValue("@enddate", dateTimePicker2.Value.Date);
            cnn.Parameters.AddWithValue("@rentalstatus", textBox5.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("delete from rentals where rentalid=@rentalid", con);
            cnn.Parameters.AddWithValue("@rentalid", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Successfully");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void Rental_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = CarSystemDB; Integrated Security = True; TrustServerCertificate = True");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from rentals", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
