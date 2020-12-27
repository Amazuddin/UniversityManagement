using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using UniversityManagement.Context;
using UniversityManagement.Models;

namespace UniversityManagement.Controllers
{
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LogIn logIn)
        {
            string password = logIn.Password;
            string email = logIn.Email;
            using (var ctx = new UniversityContext())
            {

                var p = ctx.Students.Where(c => c.Email == email && c.Password == password).Select(c => new { c.Id, c.Email }).ToList();
                if (p.Any())
                {
                    foreach (var k in p)
                    {
                        Session["StudentId"] = k.Id;
                        Session["StudentEmail"] = k.Email;

                    }
                    return RedirectToAction("Index", "University");
                }
                else
                {
                    ViewBag.Error = "Login Failed";
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["StudentId"] = null;
            Session["StudentEmail"] = null;
            return RedirectToAction("Login", "Authentication");
        }

        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            string password = admin.Password;
            string email = admin.Email;
            using (var ctx = new UniversityContext())
            {

                var p = ctx.Admins.Where(c => c.Email == email && c.Password == password).Select(c => new { c.Id, c.Email }).ToList();
                if (p.Any())
                {
                    foreach (var k in p)
                    {
                        Session["AdminId"] = k.Id;
                        Session["AdminEmail"] = k.Email;

                    }
                    return RedirectToAction("Index", "University");
                }
                else
                {
                    ViewBag.Error = "Login Failed";
                }



            }
            return View();
        }
        public ActionResult AdminLogout()
        {
            Session["AdminId"] = null;
            Session["AdminEmail"] = null;
            return RedirectToAction("AdminLogin", "Authentication");
        }
	}
}