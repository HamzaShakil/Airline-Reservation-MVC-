using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace Airline_Reservation.Models
{
    public class Connection
    {
        public static SqlConnection My_Sql_Connection;

        public static SqlConnection GetConnection()
        {
            if (My_Sql_Connection == null)
            {
                My_Sql_Connection = new SqlConnection();
                My_Sql_Connection.ConnectionString = ConfigurationManager.ConnectionStrings["Myconnection"].ToString();
                My_Sql_Connection.Open();
            }
            return My_Sql_Connection;
        }
    }
}