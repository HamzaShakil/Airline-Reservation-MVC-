using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Airline_Reservation.Models
{
    public class SearchModel
    {
        [Required]
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
        [Display(Name = "CNIC NO")]
        public int CNICNO { get; set; }
        [Display(Name = "Date Of Departure")]
        public string DateofDeparture { get; set; }
        [Display(Name = "Date Of Arival")]
        public string DateofArival { get; set; }
        [Required]
        [Display(Name = "From Location")]
        public string FromLocation { get; set; }
        [Required]
        [Display(Name = "To Location")]
        public string ToLocation { get; set; }
        [Required]
        [Display(Name = "Credit Card Type")]
        public string CreditCardType { get; set; }
        [Required]
        [DataType(DataType.CreditCard)]
        [Display(Name = "Credit Card Number")]
        public int CreditCardno { get; set; }

    }
}