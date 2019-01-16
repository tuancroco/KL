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
        public ActionResult CreateNew (string userName)
        {
           
            var user = db.Users.Single(m => m.Username == userName);
            var hoSoNhanSu = user.HoSoNhanSu;
            var viecChutri = hoSoNhanSu.CongViecPhongs.ToList().FindAll(m => m.ChuTri == 1);
            return View(viecChutri);
        }
        public ActionResult SaveNew(KhPhongModel kh,string IDNhanSu)
        {
            if (kh == null)
            {
                throw new ArgumentNullException(nameof(kh));
            }
            var IDCVPhong = kh.ID;

            db.CongViecPhongs.Where(m => m.ID == IDCVPhong).FirstOrDefault().TrangThai = 1;
            db.SaveChanges();
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
                    Datecreate=DateTime.Now
                };
                db.CongViecCaNhans.Add(CvCanhan);
                db.SaveChanges();
            }

            return RedirectToAction("ShowContent","Content",new {hosoId=IDNhanSu });
        }
        public ActionResult Report(string idJob)
        {
            var db = new Smof();
            db.CongViecCaNhans.Where(m => m.ID == idJob).FirstOrDefault().TrangThai = 2;
            db.SaveChanges();
            return View();
        }
        
    }
}