using System.Data;
using System.Data.SqlClient;
using CarSystem.Models;

namespace CarSystem.DAL
{
    public class CarDAL
    {
        public void Insert(CarModel car)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO cars VALUES(@carid,@carname,@model,@platenumber,@color,@dailyrate,@status)", con);
                cmd.Parameters.AddWithValue("@carid", car.CarID);
                cmd.Parameters.AddWithValue("@carname", car.CarName);
                cmd.Parameters.AddWithValue("@model", car.Model);
                cmd.Parameters.AddWithValue("@platenumber", car.PlateNumber);
                cmd.Parameters.AddWithValue("@color", car.Color);
                cmd.Parameters.AddWithValue("@dailyrate", car.DailyRate);
                cmd.Parameters.AddWithValue("@status", car.Status);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(CarModel car)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE cars SET carname=@carname,model=@model,platenumber=@platenumber,color=@color,dailyrate=@dailyrate,status=@status WHERE carid=@carid", con);
                cmd.Parameters.AddWithValue("@carid", car.CarID);
                cmd.Parameters.AddWithValue("@carname", car.CarName);
                cmd.Parameters.AddWithValue("@model", car.Model);
                cmd.Parameters.AddWithValue("@platenumber", car.PlateNumber);
                cmd.Parameters.AddWithValue("@color", car.Color);
                cmd.Parameters.AddWithValue("@dailyrate", car.DailyRate);
                cmd.Parameters.AddWithValue("@status", car.Status);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int carID)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM cars WHERE carid=@carid", con);
                cmd.Parameters.AddWithValue("@carid", carID);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetAll()
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM cars", con);
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
                    "SELECT * FROM cars WHERE carname LIKE @kw OR platenumber LIKE @kw OR model LIKE @kw", con);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }  // class closing
}      // namespace closing