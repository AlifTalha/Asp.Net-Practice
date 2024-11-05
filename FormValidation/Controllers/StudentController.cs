
using FormSubmission.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormSubmission.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Student());
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {

                //return RedirectToAction("Index", "Home");
                return Redirect("https://www.aiub.edu");
            }
            return View(s);
        }
    }
}
