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
            for(int i = 1; i < 3; i++)
            {
                if (Int32.Parse(chucVu.MaChucVu) > 0)
                {
                    listJob.Add(hoSoNhanSu.CongViecCaNhans.Count(m => m.TrangThai == i));
                }
                if (Int32.Parse(chucVu.MaChucVu) > 1)
                {
                    listJob.Add(hoSoNhanSu.CongViecPhongs.Count(m=>m.TrangThai==i));
                }
                if (Int32.Parse(chucVu.MaChucVu) > 2)
                {
                    listJob.Add(hoSoNhanSu.CongViecs.Count(m => m.TrangThai == i));
                }
            }
            
            return View(listJob);
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