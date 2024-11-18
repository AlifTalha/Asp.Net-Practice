
using AuthCode.DTOs;
using AuthCode.EF;
using AuthCode.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthCode.Controllers
{
    public class LoginController : Controller
    {
        AuthTableEntities db = new AuthTableEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginDTO log)
        {
            var user = (from u in db.Users
                        where u.UName.Equals(log.UName) &&
                              u.Password.Equals(log.Password)
                        select u).SingleOrDefault();

            if (user != null)
            {
                Session["user"] = user; 
                return RedirectToAction("About", "Home");
            }

            TempData["Msg"] = "User not found";
            return View();
        }
    }
}
