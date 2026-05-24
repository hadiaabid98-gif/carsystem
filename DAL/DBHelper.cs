using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CarSystem.DAL
{
    public static class DBHelper
    {
        public static string ConnectionString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CarSystemDB;Integrated Security=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}