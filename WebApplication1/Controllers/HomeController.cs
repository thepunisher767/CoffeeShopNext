using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "SWEET SWEET COFFEE!!!!!";

            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult ThankYou(string firstname, string lastname, string email, string password, string catordog, string verifypassword, string phone)
        {
            Regex emailRegex = new Regex(@"^[a-zA-Z0-9]{3,30}@[a-zA-Z0-9]{3,10}\.[a-zA-Z0-9]{2,3}$");
            Regex phoneRegex = new Regex(@"^\({0,1}[0-9]{3}\){0,1}-{0,1}\.{0,1}[0-9]{3}-{0,1}\.{0,1}[0-9]{4}$");
            bool matchEmailRegex = emailRegex.IsMatch(email);
            bool matchPhoneRegex = phoneRegex.IsMatch(phone);

            Random r = new Random();
            int lottery = r.Next(1, 4);

            if (!matchEmailRegex)
            {
                ViewBag.EmailCheck = "Email not valid.<br />";
                return View("Registration");
            }
            if (!matchPhoneRegex)
            {
                ViewBag.PhoneCheck = "Invalid phone number.<br />";
                return View("Registration");
            }
            if (verifypassword != password)
            {
                ViewBag.PasswordMatch = "Passwords do not match.<br />";
                return View("Registration");
            }
            if (catordog == "dog")
            {
                ViewBag.Animal = "Cat's are better..... =(";
            }
            else
            {
                ViewBag.Animal = "CORRECT!!!! CATS ARE AWESOME!!!!";
            }
            if (lottery != 3)
            {
                ViewBag.Lottery = "Sorry, you didn't win the lottery =(";
            }
            else
            {
                ViewBag.Lottery = "YOU WIN!!!!!..... absolutely nothing =( ";
            }
            ViewBag.FirstName = firstname;
            ViewBag.LastName = lastname;
            ViewBag.Welcome = $"Welcome, {firstname} {lastname}!!";
            ViewBag.Email = email;
            ViewBag.Phone = phone;
            return View();

        }

    }
}