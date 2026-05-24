using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CarSystem.DAL;

namespace CarSystem
{
    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT Username, Password FROM logintab WHERE Username=@username AND Password=@password", con);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Main mn = new Main();
                    mn.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Login");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}