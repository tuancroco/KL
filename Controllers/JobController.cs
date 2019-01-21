using KL.Models;
using KL.Models.DatabaseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public Smof db = new Smof();
        
        public ActionResult SaveNew(KhPhongModel kh)
        {
            if (kh == null)
            {
                throw new ArgumentNullException(nameof(kh));
            }
            var IDCVPhong = kh.ID;

            db.CongViecPhongs.Where(m => m.ID == IDCVPhong).FirstOrDefault().TrangThai = 1;
            db.SaveChanges();
            var IDNhanSu = db.HoSoNhanSus.Where(m => m.CongViecPhongs.Any(n => n.ID == kh.ID)).FirstOrDefault().ID;
            var hoso = db.HoSoNhanSus.Where(m => m.ID == IDNhanSu).FirstOrDefault();
            var id = Int32.Parse(db.CongViecCaNhans.Max(m => (m.ID)));
            var newPlans = kh.newPlans;
            foreach(var item in newPlans)
            {
                id++;
                var hoSoNhanSu = db.HoSoNhanSus.Where(m => m.ID == item.IDHs).FirstOrDefault();
                //var date = item.DeadLine != "" ? DateTime.ParseExact(item.DeadLine, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture) : DateTime.Now;
                var CvCanhan = new CongViecCaNhan()
                {
                    ID = id.ToString(),
                    Ten=item.Ten,
                    ThoiGianHoanThanh=DateTime.Now,
                    IDCongViecPhong=IDCVPhong,
                    HoSoNhanSu=hoSoNhanSu,
                    NoiDungCongViec = item.Noidung,
                    IDHoSoNhanSu=hoSoNhanSu.ID,
                    Datecreate=DateTime.Now,
                    TrangThai=0
                };
                db.CongViecCaNhans.Add(CvCanhan);
                db.SaveChanges();
            }

            return RedirectToAction("Login","Login");
        }
        public ActionResult Report(string idJob)
        {
            var db = new Smof();
            db.CongViecCaNhans.Where(m => m.ID == idJob).FirstOrDefault().TrangThai = 2;
            db.CongViecCaNhans.Where(m => m.ID == idJob).FirstOrDefault().New = 0;
            db.SaveChanges();
            return View();
        }
        public ActionResult SendRequest(string idJob,string request)
        {
            var db = new Smof();
            
            if (request == "")
            {
                db.CongViecCaNhans.Where(m => m.ID == idJob).FirstOrDefault().TrangThai = 3;
                db.CongViecCaNhans.Where(m => m.ID == idJob).FirstOrDefault().New = 0;
            }
            else 
            {
                var cncn=db.CongViecCaNhans.Where(m => m.ID == idJob).FirstOrDefault();
                db.CongViecCaNhans.Where(m => m.ID == idJob).FirstOrDefault().PhanHoi=1;
                db.CongViecCaNhans.Where(m => m.ID == idJob).FirstOrDefault().New = 0;
                var idtp = db.HoSoNhanSus.Where(m => m.CongViecCaNhans.Any(n => n.ID == idJob)).First().ID;
                var Id = db.PhanHois.Max(m => int.Parse(m.ID)) + 1;
                PhanHoi ph = new PhanHoi
                {
                    ID=Id.ToString(),
                    NoiDung=request,
                    IDCongviecCaNhan=idJob,
                    IDTruongPhong=idtp,
                    TrangThai=0
                };
                db.PhanHois.Add(ph);
            }
            
            db.SaveChanges();
            return View();
        }
    }
}