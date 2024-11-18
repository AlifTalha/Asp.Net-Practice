using AuthCode.EF;
using AuthCode.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthCode.Auth;

namespace EFwithDTO.Controllers
{
    [UserAccess]
    public class StudentController : Controller
    {
        AuthTableEntities db = new AuthTableEntities();
        public static Student Convert(StudentDTO s)
        {
            return new Student()
            {
                Id = s.Id,
                Name = s.FName + " " + s.LName,
                Dob = s.Dob,
                Cgpa = s.Cgpa,
                Age = DateTime.Now.Year - s.Dob.Year
            };
        }

        public static StudentDTO Convert(Student s)
        {
            var name = s.Name.Split(' ');
            return new StudentDTO()
            {
                Id = s.Id,
                FName = name[0],
                LName = name.Length > 1 ? name[1] : "",
                Dob = s.Dob.HasValue ? s.Dob.Value : DateTime.Now, 
                Cgpa = s.Cgpa 
            };
        }

        public static List<StudentDTO> Convert(List<Student> data)
        {
            var list = new List<StudentDTO>();
            foreach (var s in data)
            {
                list.Add(Convert(s));
            }
            return list;
        }

        public ActionResult List()
        {
            var data = db.Students.ToList();
            return View(Convert(data));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(StudentDTO s)
        {
            if (ModelState.IsValid)
            {
                var student = Convert(s);
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(s);
        }



        // Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(Convert(student));
        }

        [HttpPost]
        public ActionResult Edit(StudentDTO s)
        {
            if (ModelState.IsValid)
            {
                var student = db.Students.Find(s.Id);
                if (student == null)
                {
                    return HttpNotFound();
                }

                student.Name = s.FName + " " + s.LName;
                student.Dob = s.Dob;
                student.Cgpa = s.Cgpa;
                student.Age = DateTime.Now.Year - s.Dob.Year;

                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(s);
        }

        public ActionResult Details(int id)
        {
            var student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(Convert(student));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(Convert(student));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var student = db.Students.Find(id);
            if (student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }




    }
}