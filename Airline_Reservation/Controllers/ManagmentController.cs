using Airline_Reservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Airline_Reservation.Controllers
{
    public class ManagmentController : Controller
    {
        //
        // GET: /Managment/
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserProfile"]) == "true")
            {

                RedirectToAction("Index", "Home");
                return View();
            }
            else
            {

                //TempData["notice"] = "Invalid Password or Email";
                return RedirectToAction("Login");
            }

        }
        [HttpGet]
        public ActionResult Login()
        {

            return View();

        }
        
        [HttpPost]
        public ActionResult Login(Userlogin ul, string password)
        {
            bool chk = ul.Login(password);

            if (chk == true)
            {
                Session["UserProfile"] = "true";
                return RedirectToAction("Index", "Home");

            }
            //if (ul.Login())
            //{
            //    return RedirectToAction("Index", "Home");


            //}
            else
            {
                TempData["notice"] = "Invalid Password or UserName";
                return RedirectToAction("Login");
            }

        }
        [HttpGet]
        public ActionResult InsertCus()
        {

            if (Convert.ToString(Session["UserProfile"]) == "true")
            {

                return RedirectToAction("InsertCus");
            }
            else
            {

                //TempData["notice"] = "Invalid Password or Email";
                return RedirectToAction("Login");
            }
            //return View();
        }

        [HttpPost]
        public ActionResult InsertCus(RegistrationModel RM, string date1, string date2)
        {


            return View(RM.Insert(date1, date2));

        }
        [HttpGet]
        public ActionResult SearchCus()
        {
            if (Convert.ToString(Session["UserProfile"]) == "true")
            {
                RedirectToAction("SearchCus");
                RegistrationModel RA = new RegistrationModel();

                return View(RA);
            }
            else
            {

                //TempData["notice"] = "Invalid Password or Email";
                return RedirectToAction("Login");
            }

        }
        [HttpPost]
        public ActionResult SearchCus(RegistrationModel RM, string button, string date1, string date2)
        {
            //ModelState.Clear();
            //return View(sm.Search());
            if (button.Equals("Insert"))
            {

                RM.Insert(date1, date2);
                return RedirectToAction("SearchCus");
            }
            else if (button.Equals("Clear"))
            {
                return RedirectToAction("SearchCus");
            }
            else if (button.Equals("Update"))
            {

                RM.update_data();
                return RedirectToAction("SearchCus");
            }
            else if (button.Equals("Delete"))
            {

                RM.del_data();
                return RedirectToAction("SearchCus");
            }
            //else if (button.Equals("GetAll"))
            //{

            //    RM.getall();
            //    return RedirectToAction("GetCus");
            //}
            else
            {
                ModelState.Clear();
                return View(RM.Search());
            }
        }
        [HttpGet]
        public ActionResult GetCus()
        {
            if (Convert.ToString(Session["UserProfile"]) == "true")
            {
                RedirectToAction("GetCus");
                RegistrationModel RM = new RegistrationModel();
                return View(RM.getall());
            }
            else
            {

                //TempData["notice"] = "Invalid Password or Email";
                return RedirectToAction("Login");
            }

        }

        [HttpGet]
        public ActionResult updateCus()
        {
            if (Convert.ToString(Session["UserProfile"]) == "true")
            {
                //RedirectToAction("UpdateCus");
                RegistrationModel RM = new RegistrationModel();
                return View(RM);
            }
            else
            {

                //TempData["notice"] = "Invalid Password or Email";
                return RedirectToAction("Login");
            }




        }
        [HttpPost]
        public ActionResult updateCus(RegistrationModel RM, string button)
        {
            if (button.Equals("Search"))
            {
                ModelState.Clear();
                RedirectToAction("UpdateCus");
                return View(RM.Search());
            }
            else
            {
                RM.update_data();
                //return View();
                return RedirectToAction("UpdateCus");
            }




        }
        [HttpGet]
        public ActionResult DeleteCus()
        {


            if (Convert.ToString(Session["UserProfile"]) == "true")
            {
                RedirectToAction("DeleteCus");
                RegistrationModel RM = new RegistrationModel();
                return View(RM);
            }
            else
            {

                //TempData["notice"] = "Invalid Password or Email";
                return RedirectToAction("Login");
            }


        }
        [HttpPost]
        public ActionResult DeleteCus(RegistrationModel RM, string button,SearchModel SM)
        {

            //RM.del_data();
            if (button.Equals("Search"))
            {
                ModelState.Clear();
                RedirectToAction("DeleteCus");
                return View(RM.Search());
            }
            else
            {
                RM.del_data();
                return RedirectToAction("DeleteCus");

            }



        }
	}
}