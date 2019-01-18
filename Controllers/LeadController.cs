using KL.Models;
using KL.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KL.Controllers
{
    public class LeadController : Controller
    {
        // GET: Lead
        public ActionResult ShowContentPg(string hosoId)
        {
            var db = new Smof();
            var hoso = db.HoSoNhanSus.ToList().Find(m => m.ID == hosoId);

            List<HoSoNhanSu> dsPhong = db.HoSoNhanSus.ToList().FindAll(m => m.IDPhongBan == hoso.IDPhongBan).ToList();

            // Tạo SelectList
            SelectList cateList = new SelectList(dsPhong, "ID", "TenNhanSu");

            // Set vào ViewBag
            ViewBag.CategoryList = cateList;
            hoso.CongViecCaNhans = hoso.CongViecCaNhans.OrderBy(m => m.Datecreate).ToList();
            hoso.CongViecPhongs = hoso.CongViecPhongs.OrderBy(m => m.Datecreate).ToList();
            var hs = hoso;

            db.SaveChanges();
            return View(hs);
        }
        public ActionResult ShowWorkingPg(string hosoId)
        {
            var db = new Smof();
            var hoso = db.HoSoNhanSus.ToList().Find(m => m.ID == hosoId);
            List<Job> CvCn = new List<Job>();
            List<Job> CvPg = new List<Job>();
            foreach (var cv in hoso.CongViecCaNhans)
            {
                CvCn.Add(new Job
                {
                    Ten = cv.Ten,
                    ID = cv.ID,
                    ThoiGianHoanThanh = cv.ThoiGianHoanThanh.ToString(),
                    File = cv.CongVanDinhKemCaNhan,
                    IDkhac = cv.CongViecPhong.Ten,
                    NoiDungCongViec = cv.NoiDungCongViec
                });
            }

            foreach (var cv in hoso.CongViecPhongs)
            {
                CvPg.Add(new Job
                {
                    Ten = cv.Ten,
                    ID = cv.ID,
                    ThoiGianHoanThanh = cv.ThoiGianHoanThanh.ToString(),
                    File = cv.CongVanDinhKem,
                    IDkhac = cv.CongViec.NoiDung,
                    NoiDungCongViec = cv.NoiDungChitiet
                });
            }
            return View(hoso);
        }
        public ActionResult ShowRequest(string hosoId)
        {
            var db = new Smof();
            var hoso = db.HoSoNhanSus.ToList().Find(m => m.ID == hosoId);
            return View(hoso);
        }
        public ActionResult ShowDone(string hosoId)
        {
            var db = new Smof();
            var hoso = db.HoSoNhanSus.ToList().Find(m => m.ID == hosoId);
            return View(hoso);
        }

    }
}