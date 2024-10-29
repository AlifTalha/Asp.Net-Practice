using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.First_Name = Request["First_name"];
            ViewBag.Last_Name = Request["Last_name"];
            ViewBag.Email = Request["Email"];
            ViewBag.Phone_Number = Request["Phone_Number"];
            ViewBag.Address = Request["Address"];
            return View();
        }
        [HttpPost]
        public ActionResult Register(string First_name,string Last_Name,string Email,int Phone_Number,string Address)
        {
            ViewBag.First_Name = First_name;
            ViewBag.Last_Name = Last_Name;
            ViewBag.Email = Email;
            ViewBag.Phone_Number = Phone_Number;
            ViewBag.Address = Address;
            return View();
        }
    }
}