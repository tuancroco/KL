using KL.Models;
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
            ViewBag.hsId = hosoId;
            List<HoSoNhanSu> dsPhong = db.HoSoNhanSus.ToList().FindAll(m => m.IDPhongBan == hoso.IDPhongBan).ToList();

            // Tạo SelectList
            SelectList cateList = new SelectList(dsPhong, "ID", "TenNhanSu");

            // Set vào ViewBag
            ViewBag.CategoryList = cateList;
            var Cv = MakeJobModel(0, hoso, 1);
            
            foreach (var item in db.CongViecCaNhans.Where(m => m.HoSoNhanSu.ID == hosoId))

            {
                if (item.TrangThai < 1)
                {
                    item.TrangThai = 1;
                    item.New = 0;
                }
                
            }
            db.SaveChanges();
            return View(Cv);
        }
        public ActionResult ShowWorking(string hosoId,string maChucvu)
        {
            var db = new Smof();
            var hoso = db.HoSoNhanSus.ToList().Find(m => m.ID == hosoId);
            
            
            var Cv = MakeJobModel(1, hoso, 1);
            foreach (var item in db.CongViecCaNhans)
            {
                item.New = 1;
            }
            db.SaveChanges();
            return View(Cv);
        }
        
        public ActionResult ShowRequest(string hosoId,string maChucvu)
        {
            var db = new Smof();
            var hoso = db.HoSoNhanSus.ToList().Find(m => m.ID == hosoId);
            var Cv = MakeJobModel(2, hoso, 1);
            foreach (var item in db.CongViecCaNhans)
            {
                item.New = 1;
            }
            db.SaveChanges();
            return View(Cv);
        }
        public ActionResult ShowDone(string hosoId)
        {
            var db = new Smof();
            var hoso = db.HoSoNhanSus.ToList().Find(m => m.ID == hosoId);
            var Cv = MakeJobModel(3, hoso, 1);
            foreach (var item in db.CongViecCaNhans)
            {
                item.New = 1;
            }
            db.SaveChanges();
            return View(Cv);
        }

        public ActionResult ShowContentPg(string hosoId, string maChucVu)
        {
            var db = new Smof();
            var hoso = db.HoSoNhanSus.ToList().Find(m => m.ID == hosoId);
            var Cv = MakeJobModel(0, hoso, 2);
            ViewBag.hsId = hosoId;
            List<HoSoNhanSu> dsPhong = db.HoSoNhanSus.ToList().FindAll(m => m.IDPhongBan == hoso.IDPhongBan).ToList();

            // Tạo SelectList
            SelectList cateList = new SelectList(dsPhong, "ID", "TenNhanSu");

            // Set vào ViewBag
            ViewBag.CategoryList = cateList;
            foreach (var item in db.CongViecPhongs)
            {
                item.New = 1;
            }
            db.SaveChanges();
            return View(Cv);
        }
        public ActionResult ShowWorkingPg(string hosoId)
        {
            var db = new Smof();
            var hoso = db.HoSoNhanSus.ToList().Find(m => m.ID == hosoId);
            var Cv = MakeJobModel(1, hoso, 2);
            foreach (var item in db.CongViecPhongs)
            {
                item.New = 1;
            }
            db.SaveChanges();
            return View(Cv);
        }
        public ActionResult ShowCommitPg(string hosoId)
        {
            var db = new Smof();
            var hoso = db.HoSoNhanSus.ToList().Find(m => m.ID == hosoId);
            var Cv = CommitJob(hoso);
            foreach (var item in db.CongViecPhongs)
            {
                item.New = 1;
            }
            db.SaveChanges();
            return View(Cv);
        }

        public ActionResult Modal(string jobId)
        {
            var db = new Smof();
            var cvCn = db.CongViecCaNhans.Where(m => m.IDCongViecPhong == jobId);
            var hoso = db.HoSoNhanSus.Where(m => m.CongViecPhongs.Any(n=>n.ID==jobId)).FirstOrDefault();
            List<HoSoNhanSu> dsPhong = db.HoSoNhanSus.ToList().FindAll(m => m.IDPhongBan == hoso.IDPhongBan).ToList();

            // Tạo SelectList
            SelectList cateList = new SelectList(dsPhong, "ID", "TenNhanSu");

            // Set vào ViewBag
            ViewBag.CategoryList = cateList;
            return View(cvCn.ToList());
        }
        public List<Job> CommitJob(HoSoNhanSu hoso)
        {
            List<Job> CvCommit = new List<Job>();
            var db = new Smof();
            foreach(var cv in db.CongViecCaNhans.Where(m=>m.HoSoNhanSu.IDPhongBan==hoso.IDPhongBan&& m.TrangThai==2))
            {
                var trangthai = "";
                if (cv.TrangThai == 2) trangthai = "Request"; 
                    CvCommit.Add(new Job
                    {
                        Ten = cv.Ten,
                        ID = cv.ID,
                        ThoiGianHoanThanh = cv.ThoiGianHoanThanh.ToString(),
                        File = cv.CongVanDinhKemCaNhan,
                        IDkhac = cv.CongViecPhong.Ten,
                        NoiDungCongViec = cv.NoiDungCongViec,
                        ThoiHanHoanThanh = cv.ThoiHanHoanThanh.ToString(),
                        IDNV = hoso.ID,
                        TrangThai=trangthai,
                        PhanHoi=(cv.PhanHoi).ToString()
                    });
                cv.New = 1;
            }
            db.SaveChanges();
            return CvCommit;
        }
        public List<Job> MakeJobModel(int trangthai,HoSoNhanSu hoso,int maChucvu)
        {
            List<Job> CvCn = new List<Job>();
            List<Job> CvPg = new List<Job>();
            var db = new Smof();
            foreach (var cv in hoso.CongViecCaNhans)
            {
                if (cv.TrangThai == trangthai)
                    CvCn.Add(new Job
                    {
                        Ten = cv.Ten,
                        ID = cv.ID,
                        ThoiGianHoanThanh = cv.ThoiGianHoanThanh.ToString(),
                        File = cv.CongVanDinhKemCaNhan,
                        IDkhac = cv.CongViecPhong.Ten,
                        NoiDungCongViec = cv.NoiDungCongViec,
                        ThoiHanHoanThanh=cv.ThoiHanHoanThanh.ToString(),
                        IDNV=hoso.ID,
                        PhanHoi=cv.PhanHoi.ToString(),
                        TrangThai=cv.New.ToString()
                    });
                cv.New = 1;
            }
            db.SaveChanges();
            

            foreach (var cv in hoso.CongViecPhongs)
            {
                Job job = new Job();
                if (cv.TrangThai == trangthai)
                    job=new Job
                    {
                        Ten = cv.Ten,
                        ID = cv.ID,
                        ThoiGianHoanThanh = cv.ThoiGianHoanThanh.ToString(),
                        File = cv.CongVanDinhKem,
                        IDkhac = cv.CongViec.Ten,
                        NoiDungCongViec = cv.NoiDungChitiet,
                        ThoiHanHoanThanh=cv.ThoiHanHoanThanh.ToString(),
                        IDNV=hoso.ID,
                        TrangThai=cv.New.ToString()

                        
                    };
                cv.New = 1;
                foreach(var cvcn in CvCn)
                {
                    if (cvcn.IDkhac == cv.ID)
                    {
                        job.ListJobs.Add(cvcn);
                    }
                }
                CvPg.Add(job);
            }
            db.SaveChanges();
            List<Job> Cv = new List<Job>();
            if (maChucvu == 1) Cv = CvCn;
            else Cv = CvPg;
            return Cv;
        }
    }
}