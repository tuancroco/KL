using KL.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KL.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult ShowContent(string hosoId)
        {
            var db = new Smof();
            var hoso = db.HoSoNhanSus.ToList().Find(m => m.ID == hosoId);
            
            List<HoSoNhanSu> dsPhong = db.HoSoNhanSus.ToList().FindAll(m => m.IDPhongBan == hoso.IDPhongBan).ToList();

            // Tạo SelectList
            SelectList cateList = new SelectList(dsPhong, "ID", "TenNhanSu");

            // Set vào ViewBag
            ViewBag.CategoryList = cateList;
            return View(hoso);
        }
    }
}