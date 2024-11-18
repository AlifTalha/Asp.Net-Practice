using AuthCode.DTOs;
using AuthCode.EF;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AuthCode.Controllers
{
    public class RegistrationController : Controller
    {
        AuthTableEntities db = new AuthTableEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View(new RegisterDTO());
        }
        [HttpPost]
        public ActionResult Index(RegisterDTO reg)
        {
            if (ModelState.IsValid)
            {
                var existingUser = db.Users.FirstOrDefault(u => u.UName == reg.UName);
                if (existingUser != null)
                {
                    TempData["Msg"] = "Username already exists.";
                    return View(reg);
                }

                var newUser = new User
                {
                    Name = string.IsNullOrEmpty(reg.Name) ? "Default Name" : reg.Name,
                    UName = reg.UName,
                    Password = reg.Password,
                    Role = "User"
                };

                db.Users.Add(newUser);

                try
                {
                    db.SaveChanges();
                    TempData["Msg"] = "Registration successful. Please log in.";
                    return RedirectToAction("Index", "Login");
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            TempData["Msg"] += $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage} <br/>";
                        }
                    }
                    return View(reg);
                }
            }
            return View(reg);
        }


    }
}
