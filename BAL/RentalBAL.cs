using System;
using System.Data;
using System.Data.SqlClient;
using CarSystem.DAL;

namespace CarSystem.BAL
{
    public class RentalBAL
    {
        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = "SELECT * FROM Rentals";
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

        public bool Save(dynamic rental)
        {

            return true;
        }
        // Rentals ko update karne ke liye function
        public bool Update(dynamic rental)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {

                string query = "UPDATE Rentals SET CarID=@CarID, CustomerID=@CustomerID, RentDate=@RentDate, ReturnDate=@ReturnDate WHERE RentalID=@RentalID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@RentalID", rental.RentalID);
                    cmd.Parameters.AddWithValue("@CarID", rental.CarID);
                    cmd.Parameters.AddWithValue("@CustomerID", rental.CustomerID);
                    cmd.Parameters.AddWithValue("@RentDate", rental.RentDate);
                    cmd.Parameters.AddWithValue("@ReturnDate", rental.ReturnDate);

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
                string query = "DELETE FROM Rentals WHERE RentalID=@RentalID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RentalID", id);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }
    }
}