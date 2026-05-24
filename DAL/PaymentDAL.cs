using System.Data;
using System.Data.SqlClient;
using CarSystem.Models;

namespace CarSystem.DAL
{
    public class PaymentDAL
    {
        public void Insert(PaymentModel p)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO payments VALUES(@paymentid,@customername,@amount,@paymentmethod)", con);
                cmd.Parameters.AddWithValue("@paymentid", p.PaymentID);
                cmd.Parameters.AddWithValue("@customername", p.CustomerName);
                cmd.Parameters.AddWithValue("@amount", p.Amount);
                cmd.Parameters.AddWithValue("@paymentmethod", p.PaymentMethod);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(PaymentModel p)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE payments SET customername=@customername,amount=@amount,paymentmethod=@paymentmethod WHERE paymentid=@paymentid", con);
                cmd.Parameters.AddWithValue("@paymentid", p.PaymentID);
                cmd.Parameters.AddWithValue("@customername", p.CustomerName);
                cmd.Parameters.AddWithValue("@amount", p.Amount);
                cmd.Parameters.AddWithValue("@paymentmethod", p.PaymentMethod);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int paymentID)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM payments WHERE paymentid=@paymentid", con);
                cmd.Parameters.AddWithValue("@paymentid", paymentID);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetAll()
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM payments", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}