using System.Data;
using System.Data.SqlClient;
using CarSystem.Models;

namespace CarSystem.DAL
{
    public class MaintenanceDAL
    {
        public void Insert(MaintenanceModel m)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO maintenance VALUES(@maintenanceid,@carname,@model,@service,@cost)", con);
                cmd.Parameters.AddWithValue("@maintenanceid", m.MaintenanceID);
                cmd.Parameters.AddWithValue("@carname", m.CarName);
                cmd.Parameters.AddWithValue("@model", m.Model);
                cmd.Parameters.AddWithValue("@service", m.Service);
                cmd.Parameters.AddWithValue("@cost", m.Cost);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(MaintenanceModel m)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE maintenance SET carname=@carname,model=@model,service=@service,cost=@cost WHERE maintenanceid=@maintenanceid", con);
                cmd.Parameters.AddWithValue("@maintenanceid", m.MaintenanceID);
                cmd.Parameters.AddWithValue("@carname", m.CarName);
                cmd.Parameters.AddWithValue("@model", m.Model);
                cmd.Parameters.AddWithValue("@service", m.Service);
                cmd.Parameters.AddWithValue("@cost", m.Cost);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int maintenanceID)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM maintenance WHERE maintenanceid=@maintenanceid", con);
                cmd.Parameters.AddWithValue("@maintenanceid", maintenanceID);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetAll()
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM maintenance", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}