using System.Data;
using System.Data.SqlClient;
using CarSystem.Models;

namespace CarSystem.DAL
{
    public class CustomerDAL
    {
        public void Insert(CustomerModel c)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO customers VALUES(@customerid,@customername,@email,@phone,@address)", con);
                cmd.Parameters.AddWithValue("@customerid", c.CustomerID);
                cmd.Parameters.AddWithValue("@customername", c.CustomerName);
                cmd.Parameters.AddWithValue("@email", c.Email);
                cmd.Parameters.AddWithValue("@phone", c.Phone);
                cmd.Parameters.AddWithValue("@address", c.Address);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(CustomerModel c)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE customers SET customername=@customername,email=@email,phone=@phone,address=@address WHERE customerid=@customerid", con);
                cmd.Parameters.AddWithValue("@customerid", c.CustomerID);
                cmd.Parameters.AddWithValue("@customername", c.CustomerName);
                cmd.Parameters.AddWithValue("@email", c.Email);
                cmd.Parameters.AddWithValue("@phone", c.Phone);
                cmd.Parameters.AddWithValue("@address", c.Address);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int customerID)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM customers WHERE customerid=@customerid", con);
                cmd.Parameters.AddWithValue("@customerid", customerID);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetAll()
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM customers", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable Search(string keyword)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM customers WHERE customername LIKE @kw OR phone LIKE @kw OR email LIKE @kw", con);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}