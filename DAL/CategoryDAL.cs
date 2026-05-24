using System.Data;
using System.Data.SqlClient;
using CarSystem.Models;

namespace CarSystem.DAL
{
    public class CategoryDAL
    {
        public void Insert(CategoryModel c)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO categories VALUES(@categoryid,@carname,@categoryname)", con);
                cmd.Parameters.AddWithValue("@categoryid", c.CategoryID);
                cmd.Parameters.AddWithValue("@carname", c.CarName);
                cmd.Parameters.AddWithValue("@categoryname", c.CategoryName);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(CategoryModel c)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE categories SET carname=@carname,categoryname=@categoryname WHERE categoryid=@categoryid", con);
                cmd.Parameters.AddWithValue("@categoryid", c.CategoryID);
                cmd.Parameters.AddWithValue("@carname", c.CarName);
                cmd.Parameters.AddWithValue("@categoryname", c.CategoryName);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int categoryID)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM categories WHERE categoryid=@categoryid", con);
                cmd.Parameters.AddWithValue("@categoryid", categoryID);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetAll()
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM categories", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}