using System;
using System.Data;
using System.Data.SqlClient;
using CarSystem.DAL;
using CarSystem.Models;

namespace CarSystem.BAL
{
    public class CategoryBAL
    {

        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = "SELECT * FROM Categories";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
        // Category ko update karne ke liye
        public bool Update(CategoryModel category)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = "UPDATE Categories SET CarName=@CarName, CategoryName=@CategoryName WHERE CategoryID=@CategoryID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryID", category.CategoryID);
                    cmd.Parameters.AddWithValue("@CarName", category.CarName);
                    cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }


        public bool Delete(int id)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = "DELETE FROM Categories WHERE CategoryID=@CategoryID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryID", id);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        public bool Save(CategoryModel category)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = "INSERT INTO Categories (CarName, CategoryName) VALUES (@CarName, @CategoryName)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CarName", category.CarName);
                    cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }
    }
}