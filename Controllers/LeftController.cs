using KL.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KL.Controllers
{
    public class LeftController : Controller
    {
        // GET: Left
        public ActionResult Left(string hsId)
        {
            var db = new Smof();
            var hoSoNhanSu = db.HoSoNhanSus.Where(m => m.ID == hsId).FirstOrDefault();
            return View(hoSoNhanSu);
        }
        public ActionResult ShowLeftDonVi()
        {
            return View();
        }
       
        public ActionResult ShowLeftCaNhan(List<CongViecCaNhan> canhan)
        {
            int[] t = new int[6];
            t[0]= canhan.Count(m => m.TrangThai == 0);
            t[1] = canhan.Count(m => m.TrangThai == 1);
            t[2] = canhan.Count(m => m.TrangThai == 2);
            t[3] = canhan.Count(m => m.TrangThai == 3);
            return View(t);
        }
       
        public ActionResult ShowLeftTruongPhong(List<CongViecPhong> truongphong)
        {
            int[] t = new int[5];
            t[0] = truongphong.Count(m => m.TrangThai == 0);
            t[1] = truongphong.Count(m => m.TrangThai == 1);
            t[2] = truongphong.Count(m => m.TrangThai == 2);
            t[3] = truongphong.Count(m => m.TrangThai == 3);
            var db = new Smof();
            var hoso=truongphong.FirstOrDefault().HoSoNhanSu;
            return View(t);
        }
    }
}