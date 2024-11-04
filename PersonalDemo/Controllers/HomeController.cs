using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using personalDemo.Models;

namespace personalDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var index = new index();
            index.Name = "Alif Hossain Talha";
            index.Id = "21-44923-2";
            index.Email = "hossainalif696@gmail.com";
            ViewBag.Index = index;
            return View();
        }
        public ActionResult Education()
        {
            var e1 = new Education();
            e1.Degree = "SSC";
            e1.Year = "2017";
            e1.Institute = "NGBHS";

            var e2 = new Education();
            e2.Degree = "HSC";
            e2.Year = "2019";
            e2.Institute = "NS College";

            var e3 = new Education();
            e3.Degree = "Bsc in CSE";
            e3.Year = "2024";
            e3.Institute = "AIUB";

            ViewBag.Educations = new Education[] { e1, e2, e3 };
            return View();
        }
        public ActionResult Personal()
        {
            ViewBag.Message = "Hi , Welcome to my Page!";
            var person = new personInfo();
            person.FirstName = "Alif";
            person.LastName = "Talha";
            person.FatherName = "";
            person.MotherName = "";
            person.DateOfBirth = new DateTime(3000, 03, 11);
            person.BloodGroup = "O+";
            person.MobileNumber = "01605080977";
            person.Email = "hossainalif696@gmail.com";
            person.Address = "Dhaka";
            person.Website = new Uri("https://www.example.com");
            ViewBag.personInfo = person;
            return View();
        }
        public ActionResult Projects()
        {
            var p1 = new Projects();
            p1.ProjectName = "Sports Management System";
            p1.ProjectDescription = new string[] { "hi for p1" };


            var p2 = new Projects();
            p2.ProjectName = "Metro-Rail Management System";
            p2.ProjectDescription = new string[] { "hi for p1" };

            var p3 = new Projects();
            p3.ProjectName = "Shopping Management System";
            p3.ProjectDescription = new string[] { "hi for p1" };

            ViewBag.Projects=new Projects[] { p1, p2, p3 };
            return View();
        }
        public ActionResult Reference()
        {
            var r1 = new Reference();
            r1.Name = "Shibaji Mridha";
            r1.Designation = "Assistant Professor,";
            r1.Organization = "Faculty of Arts & Social Science,";
            r1.MobileNumber = "+1234567890";
            r1.Email = "smridha@aiub.edu";

            var r2 = new Reference();
            r2.Name = "Zahiduddin Ahmed";
            r2.Designation = "Assistant Professor";
            r2.Organization = "Faculty Of Science And Technology";
            r2.MobileNumber = "+1234567890";
            r2.Email = "zahid@aiub.edu";

            ViewBag.References = new Reference[] { r1, r2 };

            return View();
        }
    }

}