using KL.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KL.Controllers
{
    public class JobController : Controller
    {
        // GET: Job
        public ActionResult CreateJob()
        {
            return View();
        }
        public ActionResult CreateNew (string userName)
        {
            var db = new Smof();
            var user = db.Users.Single(m => m.Username == userName);
            var hoSoNhanSu = user.HoSoNhanSu;
            var viecChutri = hoSoNhanSu.CongViecPhongs.ToList().FindAll(m => m.ChuTri == 1);
            return View(viecChutri);
        }
    }
}