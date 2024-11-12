using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DepartmentDTO.DTOs;
using DepartmentDTO.EF;

namespace DepartmentDTO.Controllers
{
    public class DepartmentController : Controller
    {
        StudentDTOEntities db = new StudentDTOEntities(); 
        public static Department Convert(DepartDTO d)
        {
            return new Department()
            {
                Id = d.Id,
                Name = d.Name,
            };
        }
        public static DepartDTO Convert(Department d)
        {
            return new DepartDTO()
            {
                Id = d.Id,
                Name = d.Name,
            };
        }
        public static List<DepartDTO> Convert(List<Department> data)
        {
            var list = new List<DepartDTO>();
            foreach (var d in data)
            {
                list.Add(Convert(d));
            }
            return list;
        }
        public ActionResult List()
        {
            var data = db.Departments.ToList();
            return View(Convert(data));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new DepartDTO());
        }
        [HttpPost]
        public ActionResult Create(DepartDTO d)
        {
            if (ModelState.IsValid)
            {
                var data = new Department()
                {
                    Name = d.Name,
                };
                db.Departments.Add(data);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(d);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.Departments.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(Convert(data));
        }

        [HttpPost]
        public ActionResult Edit(DepartDTO d)
        {
            if (ModelState.IsValid)
            {
                var data = db.Departments.Find(d.Id);
                if (data != null)
                {
                    data.Name = d.Name;
                    db.SaveChanges();
                }
                return RedirectToAction("List");
            }
            return View(d);
        }


        public ActionResult Details(int id)
        {
            var data = db.Departments.Find(id);
            return View(Convert(data));
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = db.Departments.Find(id);
            return View(Convert(data));
        }
        [HttpPost]
        public ActionResult Delete(int Id, string dcsn)
        {
            if(dcsn.Equals("Yes"))
            {
                var data = db.Departments.Find(Id);
                db.Departments.Remove(data);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}