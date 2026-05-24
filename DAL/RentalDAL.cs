using System.Data;
using System.Data.SqlClient;
using CarSystem.Models;

namespace CarSystem.DAL
{
    public class RentalDAL
    {
        public void Insert(RentalModel r)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO rentals VALUES(@rentalid,@customername,@carname,@model,@startdate,@enddate,@rentalstatus)", con);
                cmd.Parameters.AddWithValue("@rentalid", r.RentalID);
                cmd.Parameters.AddWithValue("@customername", r.CustomerName);
                cmd.Parameters.AddWithValue("@carname", r.CarName);
                cmd.Parameters.AddWithValue("@model", r.Model);
                cmd.Parameters.AddWithValue("@startdate", r.StartDate);
                cmd.Parameters.AddWithValue("@enddate", r.EndDate);
                cmd.Parameters.AddWithValue("@rentalstatus", r.RentalStatus);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(RentalModel r)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE rentals SET customername=@customername,carname=@carname,model=@model,startdate=@startdate,enddate=@enddate,rentalstatus=@rentalstatus WHERE rentalid=@rentalid", con);
                cmd.Parameters.AddWithValue("@rentalid", r.RentalID);
                cmd.Parameters.AddWithValue("@customername", r.CustomerName);
                cmd.Parameters.AddWithValue("@carname", r.CarName);
                cmd.Parameters.AddWithValue("@model", r.Model);
                cmd.Parameters.AddWithValue("@startdate", r.StartDate);
                cmd.Parameters.AddWithValue("@enddate", r.EndDate);
                cmd.Parameters.AddWithValue("@rentalstatus", r.RentalStatus);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int rentalID)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM rentals WHERE rentalid=@rentalid", con);
                cmd.Parameters.AddWithValue("@rentalid", rentalID);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetAll()
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM rentals", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}