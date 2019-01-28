using KL.Models;
using KL.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KL.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        public static string userId = "";
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ClickLogin()
        {

            return View();
        }
        public ActionResult ShowTaskPercent()
        {
            var db = new Smof();
            var hs = db.HoSoNhanSus.Where(m => m.ID == userId).First();
            var listTask = new List<taskTimeModel>();
            if (int.Parse(hs.ChucVu.MaChucVu) > 0)
            {
                listTask.Add(new taskTimeModel
                {
                    jobName = "cong viec ca nhan",
                    percent = 80,
                });
            }
            if (int.Parse(hs.ChucVu.MaChucVu) > 1)
            {
                listTask.Add(new taskTimeModel
                {
                    jobName = "cong viec phong",
                    percent = 80,
                });
            }
            
            return View(listTask);
        }
        public ActionResult Search(string Id)
        {
            userId = Id;
            return View();
        }
        
        public ActionResult ShowSearch(Search search)
        {
            List<Job> list = new List<Job>();
            var db = new Smof();
            var t = new ContentController();
            var hoso = db.HoSoNhanSus.Where(m => m.ID == userId).First();
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    list.AddRange(t.MakeJobModel(i, hoso, j));
                }
                
            }
            list = list.Where(m => m.Ten.Contains(search.field)).ToList();
            return View(list.ToList());
        }
    }
}