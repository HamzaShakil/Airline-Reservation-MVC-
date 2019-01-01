using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Airline_Reservation.Models
{
    public class RegistrationModel
    {
        
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Your ID")]
        public int Customerid { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string CusFName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string CusLName { get; set; }
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "CNIC NO")]
        public int CNICNO { get; set; }
        [Required]
        [Display(Name = "Date Of Departure")]
        public string DateofDeparture { get; set; }
        [Required]
        [Display(Name = "Date Of Arival")]
        public string DateofArival { get; set; }
        [Required]
        //[Required]
        [Display(Name = "From Location")]
        public string FromLocation { get; set; }
        [Required]
        [Display(Name = "To Location")]
        public string ToLocation { get; set; }
        [Required]
        [Display(Name = "Credit Card Type")]
        public string CreditCardType { get; set; }
        [Required]
        [DataType (DataType.PhoneNumber)]
        [Display(Name = "Credit Card Number")]
        public int CreditCardno { get; set; }

        public bool Insert(string date1, string date2)
        {
            SqlCommand sql = new SqlCommand("InsertCustomerInfo", Connection.GetConnection());
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@CusFName", this.CusFName);
            sql.Parameters.AddWithValue("@CusLName", this.CusLName);
            sql.Parameters.AddWithValue("@Gender", this.Gender);
            sql.Parameters.AddWithValue("@CusEmail", this.Email);
            sql.Parameters.AddWithValue("@CNICNO", this.CNICNO);
            sql.Parameters.AddWithValue("@DateOFDep", date1);
            sql.Parameters.AddWithValue("@DateOFArr", date2);
            sql.Parameters.AddWithValue("@FromLocation", this.FromLocation);
            sql.Parameters.AddWithValue("@ToLocation", this.ToLocation);
            sql.Parameters.AddWithValue("@CreditCardType", this.CreditCardType);
            sql.Parameters.AddWithValue("@CreditCardNo", this.CreditCardno);
            int chk = sql.ExecuteNonQuery();
            if (chk < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public RegistrationModel Search()
        {
            SqlCommand sql = new SqlCommand("Customersearch", Connection.GetConnection());
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@CusID", this.Customerid);
            SqlDataReader sdr = sql.ExecuteReader();
            RegistrationModel RA = new RegistrationModel();
            while (sdr.Read())
            {
                RA.Customerid = Convert.ToInt32(sdr["CusId"]);
                RA.CusFName = sdr["CusFName"].ToString();
                RA.CusLName = sdr["CusLName"].ToString();
                RA.Gender = sdr["Gender"].ToString();
                RA.Email = sdr["Email"].ToString();
                RA.CNICNO = Convert.ToInt32(sdr["CNICNO"]);
                RA.DateofDeparture = sdr["Dep_Time"].ToString();
                RA.DateofArival = sdr["Arr_Time"].ToString();
                RA.FromLocation = sdr["FromLocation"].ToString();
                RA.ToLocation = sdr["ToLocation"].ToString();
                RA.CreditCardType = sdr["CreditCardType"].ToString();
                RA.CreditCardno = Convert.ToInt32(sdr["CreditCardno"]);
                //list.Add(RA);
                break;

            }
            sdr.Close();
            return RA;
        }

        public List<RegistrationModel> getall()
        {
            List<RegistrationModel> list = new List<RegistrationModel>();
            SqlCommand sql = new SqlCommand("GetAllCus", Connection.GetConnection());
            sql.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sql.ExecuteReader();
            while (sdr.Read())
            {
                RegistrationModel RA = new RegistrationModel();
                RA.Customerid = Convert.ToInt32(sdr["CusID"]);
                RA.CusFName = sdr["CusFName"].ToString();
                RA.CusLName = sdr["CusLName"].ToString();
                RA.Gender = sdr["Gender"].ToString();
                RA.Email = sdr["Email"].ToString();
                RA.CNICNO = Convert.ToInt32(sdr["CNICNO"]);
                RA.DateofDeparture = sdr["Dep_Time"].ToString();
                RA.DateofArival = sdr["Arr_Time"].ToString();
                RA.FromLocation = sdr["FromLocation"].ToString();
                RA.ToLocation = sdr["ToLocation"].ToString();
                RA.CreditCardType = sdr["CreditCardType"].ToString();
                RA.CreditCardno = Convert.ToInt32(sdr["CreditCardno"]);
                list.Add(RA);
            }
            sdr.Close();
            return list;
        }


        public void update_data()
        {

            SqlCommand sql = new SqlCommand("Update_Cus", Connection.GetConnection());
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@CusID", this.Customerid);
            sql.Parameters.AddWithValue("@CusFname", this.CusFName);
            sql.Parameters.AddWithValue("@CusLname", this.CusLName);
            sql.Parameters.AddWithValue("@Gender", this.Gender);
            sql.Parameters.AddWithValue("@CusEmail", this.Email);
            sql.Parameters.AddWithValue("@CNICNO", this.CNICNO);
            sql.Parameters.AddWithValue("@DateOFDep", this.DateofDeparture);
            sql.Parameters.AddWithValue("@DateOFArr", this.DateofArival);
            sql.Parameters.AddWithValue("@FromLocation", this.FromLocation);
            sql.Parameters.AddWithValue("@ToLocation", this.ToLocation);
            sql.Parameters.AddWithValue("@CreditCardType", this.CreditCardType);
            sql.Parameters.AddWithValue("@CreditCardNo", this.CreditCardno);

            sql.ExecuteNonQuery();
        }
        public void del_data()
        {
            SqlCommand sq_com = new SqlCommand("deleteCustomer", Connection.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@CusID", this.Customerid);
            sq_com.ExecuteNonQuery();

        }

    }
}