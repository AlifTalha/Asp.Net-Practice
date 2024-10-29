using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Name = Request["Name"];
            ViewBag.Id = Request["Id"];
            ViewBag.Code=Request["Code"];

            return View();
        }
        [HttpPost]
        public ActionResult Create(string Name, int Id, int Code)
        {
            ViewBag.Name = Name;
            ViewBag.Id = Id;
            ViewBag.Code = Code;
            return View();
        }
        //[HttpPost]
        //public ActionResult Create(FormCollection fc) {
        //    ViewBag.Name = fc["Name"];
        //    ViewBag.Id = fc["Id"];
        //    ViewBag.Code=fc["Code"];

        //    return View();
    
    }
}