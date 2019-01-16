using KL.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string userName)
        {
            var db = new Smof();
           var user = db.Users.Single(m => m.Username == userName);
            var hoSoNhanSu = user.HoSoNhanSu;
            var chucVu = hoSoNhanSu.ChucVu;
            var listJob = new List<dynamic>();
            TempData["userName"] = userName;
            return View(hoSoNhanSu);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}