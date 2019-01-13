using KL.Models;
using KL.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KL.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login form)
        {
            var db = new Smof();
            var user = db.Users.ToList();
            if (user.Any(m => m.Username == form.userName))
            {
                var currentUser = user.Find(m => m.Username == form.userName);
                if (currentUser.Password == form.passWord)
                {
                    ViewBag.alert = "";
                    return RedirectToAction("Index", "Home", new { userName = form.userName });
                }
            }
            ViewBag.alert = "The password or username is not correct";
            return View();
            
        }
    }
}