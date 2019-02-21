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
        public ActionResult ShowTaskPercent(string userID)
        {
            var db = new Smof();
            var hs = db.HoSoNhanSus.Where(m => m.ID == userID).First();
            var listTask = new List<taskTimeModel>();
            var cn = 1;
            var pcn = hs.CongViecCaNhans.Count(m => m.TrangThai == 3);
            var ppg = hs.CongViecPhongs.Count(m => m.TrangThai == 3);
            if (hs.CongViecCaNhans.Count > 0) cn = hs.CongViecCaNhans.Count;
            var pg = 1;
            if (hs.CongViecPhongs.Count > 0) pg = hs.CongViecPhongs.Count;
            if (int.Parse(hs.ChucVu.MaChucVu) > 0)
            {
                listTask.Add(new taskTimeModel
                {
                    jobName = "cong viec ca nhan",
                    percent = pcn*100/cn,
                });
            }
            if (int.Parse(hs.ChucVu.MaChucVu) > 1)
            {
                listTask.Add(new taskTimeModel
                {
                    jobName = "cong viec phong",
                    percent = ppg*100/pg,
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
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    list.AddRange(t.MakeJobModel(i, hoso, j));
                }
                
            }
            var field = "";
            if (search.field != null) field = search.field;
            list = list.Where(m => m.Ten.Contains(field)).ToList();
            list=list.OrderByDescending(m => m.vitriCv).ToList();
            return View(list.ToList());
        }
        public ActionResult ThongKe()
        {
            return View();
        }
        public static List<Job> jobs=new List<Job>();
        public static List<string> listSort = new List<string>();
        public static int pagSize=5;
        public static int pagNum=1;
        public ActionResult ShowThongKe(ThongKe t, SortModel Sort,int button=0)
        {
             var db = new Smof();
            var hoso = db.HoSoNhanSus.Where(m => m.ID == userId).First();
            pagNum = t.pagnumber == 0 ? pagNum : t.pagnumber;
            pagSize = t.pagsize == 0 ? pagSize : t.pagsize;
            ViewBag.number = pagNum;
            ViewBag.pagsize = pagSize;
            if (Sort.col != null)
            {
                foreach(var pro in new Job().GetType().GetProperties())
                {
                    if (pro.Name.ToString().ToLower().Contains(Sort.col))
                    {
                        if (Sort.orderBy == "asc")
                        {
                            jobs = jobs.OrderBy(m => pro.GetValue(m)).ToList();
                        }
                        else if(Sort.orderBy=="desc")
                        {
                            jobs = jobs.OrderByDescending(m => pro.GetValue(m)).ToList();
                        }
                        
                    }
                }
                return View(jobs.Skip((pagNum - 1) * pagSize).Take(pagSize).ToList());
            } 
            if (button > 0)
            {
                pagNum = button;
                ViewBag.number = pagNum;
                return View(jobs.Skip((button - 1) * pagSize).Take(pagSize).ToList());
            }
            var tt = new ContentController();
            List<Job> list = new List<Job>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    list.AddRange(tt.MakeJobModel(i, hoso, j));
                }

            }
            if (t.loaiCv != 6)
            {
                list = list.Where(m => m.vitriCv == t.loaiCv).ToList();
            }
            if (t.ttCv != 6)
            {
                list = list.Where(m => m.TrangThai == t.ttCv.ToString()).ToList();
            }
            var x = list[0].ThoiHanHoanThanh.CompareTo(t.fromdate.ToString("yyyy-MM-dd"));
            var c= list[0].ThoiHanHoanThanh.CompareTo(t.todate.ToString("yyyy-MM-dd"));
            list = list.Where(m => m.ThoiHanHoanThanh.CompareTo(t.fromdate.ToString("yyyy-MM-dd")) >=0 && m.ThoiHanHoanThanh.CompareTo(t.todate.ToString("yyyy-MM-dd"))<=0).ToList();
            //list = list.Where(m => m.Ten.Contains(search)).ToList();
            jobs = list;
           
            return  View(jobs.Skip(( pagNum- 1) * pagSize).Take(pagSize).ToList()); 
        }
        public ActionResult PageSort(SortModel sort)
        {

            return RedirectToAction("ShowThongKe",new { Sort = sort });
        }
        public ActionResult PageChange(string pagbutton)
        {
            return RedirectToAction("ShowThongKe", new { button = int.Parse(pagbutton) });
        }
        public ActionResult Paging()
        {
            int total= (int)Math.Ceiling((decimal)jobs.Count / (pagSize));
            return View(new List<int> { total,pagNum });
        }
    }
}