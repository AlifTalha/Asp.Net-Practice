
using IntroEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroEF.Controllers
{
    public class StudentController : Controller
    {
        Student_CEntities2 db = new Student_CEntities2();

        [HttpGet]
        public ActionResult CreateCourse()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult CreateCourse(Cours course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("CourseList");
            }
            return View(course);
        }

       
        public ActionResult CourseList()
        {
            var courses = db.Courses.ToList();
            return View(courses);
        }

       
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student1 s)
        {
            db.Student1.Add(s);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            var data = db.Student1.ToList();
            return View(data);
        }

        public ActionResult Details(int id)
        {
            var data = db.Student1.Find(id);
            if (data == null)
            {
                TempData["Msg"] = "Id with value " + id + " not found";
                return RedirectToAction("List");
            }
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.Student1.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student1 formObj)
        {
            var exObj = db.Student1.Find(formObj.Id);
            formObj.Cgpa = exObj.Cgpa;
            db.Entry(exObj).CurrentValues.SetValues(formObj);
            //exObj.Name = formObj.Name;
            //exObj.Cgpa = formObj.Cgpa;
            db.SaveChanges();
            return RedirectToAction("List");


        }

        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = db.Student1.Find(id);
            if (data == null)
            {
                TempData["Msg"] = "Student with ID " + id + " not found.";
                return RedirectToAction("List");
            }

           
            return View(data);
        }

        [HttpPost]
        public ActionResult Delete(Student1 student)
        {
            var data = db.Student1.Find(student.Id);

            if (data != null)
            {
                db.Student1.Remove(data);
                db.SaveChanges();
                TempData["Msg"] = "Student deleted successfully.";
            }
            else
            {
                TempData["Msg"] = "Student not found.";
            }

           
            return RedirectToAction("List");
        }



    }
}
