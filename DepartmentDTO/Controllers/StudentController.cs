

using DepartmentDTO.DTOs;
using DepartmentDTO.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DepartmentDTO.Controllers
{
    public class StudentController : Controller
    {
        // Database context
        StudentDTOEntities db = new StudentDTOEntities();

        // Converts StudentDTO to Student
        public static Student Convert(StudentDTO s)
        {
            return new Student()
            {
                Id = s.Id,
                Name = s.FName + " " + s.LName,
                Dob = s.Dob,
                Age = DateTime.Now.Year - s.Dob.Year,
                Cgpa = s.Cgpa
            };
        }

        // Converts Student to StudentDTO
        public static StudentDTO Convert(Student s)
        {
            var nameParts = s.Name?.Split(' ');
            return new StudentDTO()
            {
                Id = s.Id,
                FName = nameParts?.Length > 0 ? nameParts[0] : "",
                LName = nameParts?.Length > 1 ? nameParts[1] : "",
                Dob = s.Dob,
                Cgpa = s.Cgpa
            };
        }

        // Converts a list of Student entities to StudentDTOs
        public static List<StudentDTO> Convert(List<Student> data)
        {
            var list = new List<StudentDTO>();
            foreach (var s in data)
            {
                list.Add(Convert(s));
            }
            return list;
        }

        // List Action
        public ActionResult List()
        {
            var data = db.Students.ToList();
            return View(Convert(data));
        }

        // GET: Create Action
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create Action
        [HttpPost]
        public ActionResult Create(StudentDTO s)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(Convert(s));
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(s);
        }
    }
}
