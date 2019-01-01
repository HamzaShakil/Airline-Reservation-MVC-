using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Airline_Reservation.Models
{

    public class Userlogin
    {
        [Required]
        [Display(Name = "User Name")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }

        public bool RememberMe { get; set; }
        public bool Login(string password)
        {
            SqlCommand sc = new SqlCommand("Cus_login", Connection.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@UserName", this.Username);
            sc.Parameters.AddWithValue("@UserPassword", password);
            SqlDataReader sdr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            sdr.Close();
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}