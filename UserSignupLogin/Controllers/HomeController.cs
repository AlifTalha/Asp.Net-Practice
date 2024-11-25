using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Web.Mvc;
using UserSignupLogin.Model; // Importing the models

namespace UserSignupLogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBuserSignupLoginEntities1 db = new DBuserSignupLoginEntities1();

        // Home Page (Index)
        public ActionResult Index()
        {
            if (Session["UsernameSS"] != null)
            {
                ViewBag.Username = Session["UsernameSS"].ToString();
                return View();
            }
            return RedirectToAction("Login");
        }

        // Register (Signup Page)
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(TBLUserInfo tBLUserInfo)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Please fill in all required fields.";
                return View(tBLUserInfo);
            }

            if (db.TBLUserInfoes.Any(x => x.UsernameUs == tBLUserInfo.UsernameUs))
            {
                ViewBag.Error = "This username is already taken.";
                return View(tBLUserInfo);
            }

            try
            {
                // Save the password as-is (not hashed)
                db.TBLUserInfoes.Add(tBLUserInfo);
                db.SaveChanges();

                ViewBag.Success = "Registration successful! You can now log in.";
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error while saving data: " + ex.Message;
                return View(tBLUserInfo);
            }
        }


        // Login Page
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Both username and password are required.";
                return View();
            }

            try
            {
                // Validate the user credentials
                var user = db.TBLUserInfoes.FirstOrDefault(u => u.UsernameUs == username && u.PasswordUs == password);

                if (user != null)
                {
                    // Save user data in session
                    Session["IdUsSS"] = user.IdUs.ToString();
                    Session["UsernameSS"] = user.UsernameUs;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Invalid username or password.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error during login: " + ex.Message;
                return View();
            }
        }


        // Logout
        public ActionResult Logout()
        {
            Session.Clear(); // Clear session data
            return RedirectToAction("Login", "Home");
        }

        // Show All Registered Users
        public ActionResult UserList()
        {
            if (Session["UsernameSS"] == null)
            {
                return RedirectToAction("Login");
            }

            // Retrieve users list from the database
            var users = db.TBLUserInfoes.ToList();
            return View(users);
        }

        // Hash Password Method
        private string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return string.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
