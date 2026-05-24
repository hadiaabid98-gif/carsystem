using System;
using System.Data;
using System.Data.SqlClient;
using CarSystem.DAL;

namespace CarSystem.BAL
{
    public class PaymentBAL
    {
        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = "SELECT * FROM Payments";
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


        public bool Save(dynamic payment)
        {

            return true;
        }

        public bool Update(dynamic payment)
        {

            return true;
        }

        public bool Delete(int id)
        {

            return true;
        }
    }
}