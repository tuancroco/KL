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
       
        public ActionResult ShowLeftCaNhan(string Id)
        {
            var db = new Smof();
            var truongphong = db.CongViecCaNhans.Where(m => m.IDHoSoNhanSu == Id);
            List<List<int>> list = new List<List<int>>();
            for (int i = 0; i < 6; i++)
            {
                
                {
                    var t1 = new List<int> { truongphong.Count(m => m.TrangThai == i), truongphong.Count(m => m.New == 0 && m.TrangThai == i) };
                    list.Add(t1);
                }
            }
            List<int> id = new List<int> { int.Parse(Id) };
            list.Add(id);
            return View(list);
        }
       
        public ActionResult ShowLeftTruongPhong(string Id)
        {
            var db = new Smof();
            var truongphong = db.CongViecPhongs.Where(m => m.IDHoSoNhanSuPhuTrach == Id);
            List<List<int>> list = new List<List<int>>();
            for(int i = 0; i < 5; i++)
            {
                var t1=new List<int> { truongphong.Count(m => m.TrangThai == i), truongphong.Count(m => m.New == 0 && m.TrangThai == i), truongphong.Count(m=>m.TrangThai==1&&m.CongViecCaNhans.Any(n=>n.TrangThai==2)) };
                list.Add(t1);
            }
            List<int> id = new List<int> { int.Parse(Id) };
            list.Add(id);
            return View(list);
        }
        public ActionResult ShowLeftVanThu(string Id)
        {
            var db = new Smof();
            var truongphong = db.CongViecs.Where(m => m.IDHoSoNhanSu == Id);
            List<List<int>> list = new List<List<int>>();
            for (int i = 0; i < 5; i++)
            {
                var t1 = new List<int> { truongphong.Count(m => m.TrangThai == i), truongphong.Count(m => m.New == 0 && m.TrangThai == i) };
                list.Add(t1);
            }
            List<int> id = new List<int> { int.Parse(Id) };
            list.Add(id);
            return View(list);
        }
        public ActionResult ShowLeftLanhDao(string Id)
        {
            var db = new Smof();
            
            var truongphong = db.CongViecPhongs;
            List<List<int>> list = new List<List<int>>();
            for (int i = 0; i < 5; i++)
            {
                var t1 = new List<int> { truongphong.Count(m => m.TrangThai == i), truongphong.Count(m => m.New == 0 && m.TrangThai == i) };
                list.Add(t1);
            }
            List<int> id = new List<int> { int.Parse(Id) };
            list.Add(id);
            return View(list);
        }
    }
}