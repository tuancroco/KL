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
        public ActionResult ShowContent(string hosoId,int ma)
        {
            var db = new Smof();
            var hoso = db.HoSoNhanSus.ToList().Find(m => m.ID  == hosoId);
            ViewBag.hsId = hosoId;
            List<HoSoNhanSu> dsPhong = db.HoSoNhanSus.ToList().FindAll(m => m.IDPhongBan == hoso.IDPhongBan).ToList();

            // Tạo SelectList
            SelectList cateList = new SelectList(dsPhong, "ID", "TenNhanSu");

            // Set vào ViewBag
            ViewBag.CategoryList = cateList;
            var Cv = MakeJobModel(0, hoso, ma);
            SaveData(ma, hosoId,0);
          
            return View(Cv);
        }
        public void SaveData(int ma,string hosoId,int click)
        {
            var db = new Smof();
            var hoso = db.HoSoNhanSus.ToList().Find(m => m.ID == hosoId);
            if (ma == 1)
            {
                foreach (var item in hoso.CongViecCaNhans.Where(m => m.TrangThai == click))

                {
                    item.New = 1;
                    if (click == 2 || click==5)
                    {
                        if (item.PhanHoi == 0)
                        {
                            if (item.NoiDungPhanHoi == "Done")
                            {
                                item.TrangThai = 3;
                            }
                            else
                            {
                                item.TrangThai = 1;
                            }

                            item.New = 0;
                        }
                    }
                    
                    item.PhanHoi = 1;
                    db.SaveChanges();
                    if (item.TrangThai < 1)
                    {
                        item.TrangThai = 1;
                        item.New = 0;
                        
                       
                    }

                }
            }
            else if (ma == 2)
            {
                foreach (var item in hoso.CongViecPhongs.Where(m => m.HoSoNhanSu.ID == hosoId))

                {
                    {
                        item.New = 1;
                        if (click == 2)
                        {
                            if (item.PhanHoi == 0)
                            {
                                if (item.NoiDungPhanHoi == "Done")
                                {
                                    item.TrangThai = 3;
                                }
                                else
                                {
                                    item.TrangThai = 1;
                                }

                                item.New = 0;
                            }
                        }

                        item.PhanHoi = 1;
                        db.SaveChanges();
                        if (item.TrangThai < 1)
                        {
                            item.TrangThai = 1;
                            item.New = 0;


                        }

                    }

                }
            }
            else if (ma == 3)
            {
                foreach (var item in hoso.CongViecPhongs.Where(m => m.HoSoNhanSu.ID == hosoId))

                {
                    {
                        item.New = 1;
                        if (click == 2)
                        {
                            if (item.PhanHoi == 0)
                            {
                                if (item.NoiDungPhanHoi == "Done")
                                {
                                    item.TrangThai = 3;
                                }
                                else
                                {
                                    item.TrangThai = 1;
                                }

                                item.New = 0;
                            }
                        }

                        item.PhanHoi = 1;
                        db.SaveChanges();
                        if (item.TrangThai < 1)
                        {
                            item.TrangThai = 1;
                            item.New = 0;


                        }

                    }

                }
            }
            else
            {
                foreach (var item in hoso.CongViecs.Where(m => m.HoSoNhanSu.ID == hosoId))

                {
                    {
                        item.New = 1;
                        if (click == 2)
                        {
                            if (item.PhanHoi == 0)
                            {
                                if (item.NoiDungPhanHoi == "Done")
                                {
                                    item.TrangThai = 3;
                                }
                                else
                                {
                                    item.TrangThai = 1;
                                }

                                item.New = 0;
                            }
                        }

                        item.PhanHoi = 1;
                        db.SaveChanges();
                        if (item.TrangThai < 1)
                        {
                            item.TrangThai = 1;
                            item.New = 0;


                        }

                    }

                }
            }

            db.SaveChanges();
        }
        public ActionResult ShowWorking(string hosoId,int ma)
        {
            var db = new Smof();
            var hoso = db.HoSoNhanSus.ToList().Find(m => m.ID == hosoId);
            
            
            var Cv = MakeJobModel(1, hoso, ma);
            SaveData(ma, hosoId,1);
            return View(Cv);
        }
        
        public ActionResult ShowRequest(string hosoId,int ma)
        {
            var db = new Smof();
            var hoso = db.HoSoNhanSus.ToList().Find(m => m.ID == hosoId);
            var Cv = MakeJobModel(2, hoso, ma);
            var cv1 = MakeJobModel(5, hoso, ma);
            SaveData(ma, hosoId,2);
            SaveData(ma, hosoId, 5);
            Cv.AddRange(cv1);
            return View(Cv);
        }
        public ActionResult ShowDone(string hosoId,int ma)
        {
            var db = new Smof();
            var hoso = db.HoSoNhanSus.ToList().Find(m => m.ID == hosoId);
            var Cv = MakeJobModel(3, hoso, ma);
            SaveData(ma, hosoId,3);
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
            foreach (var item in hoso.CongViecPhongs.Where(m => m.TrangThai == 0))
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
            SaveData(2, hosoId, 1);
            db.SaveChanges();
            return View(Cv);
        }
        public ActionResult ShowCommitPg(string hosoId)
        {
            var db = new Smof();
            var hoso = db.HoSoNhanSus.ToList().Find(m => m.ID == hosoId);

            foreach (var item in hoso.CongViecPhongs.Where(m => m.TrangThai == 2))
            {
                item.New = 1;
            }
            db.SaveChanges();
            return View();
        }
        
        public ActionResult CreateJobPg(string hosoId)
        {

            return View();
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
        public ActionResult ShowCommitld(string jobId)
        {
            var db = new Smof();
            var cvCn = db.CongViecPhongs.Where(m => m.TrangThai==2);
            
            return View(cvCn.ToList());
        }
        public List<Job> CommitJob(HoSoNhanSu hoso)
        {
            List<Job> CvCommit = new List<Job>();
            var db = new Smof();
            foreach(var cv in db.CongViecCaNhans.Where(m=>m.HoSoNhanSu.IDPhongBan==hoso.IDPhongBan&& m.TrangThai==2))
            {
                var trangthai = "";
                var phooi = "";
                var th = 1;
                if (cv.PhanHoi != null) th = cv.PhanHoi.Value;
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
                    TrangThai = trangthai,
                    New = cv.New.ToString(),
                    slPh = cv.PhanHois.Count,
                    PhanHoi = cv.NoiDungPhanHoi,
                    TrangThaiPh =th 
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
            List<Job> CvVt = new List<Job>();
            var db = new Smof();
            foreach (var cv in hoso.CongViecCaNhans)
            {
                var trangthai1 = "";
                var phooi = "";
                var th = 1;
                if (cv.PhanHoi != null) th = cv.PhanHoi.Value;
                if (cv.TrangThai == 2) trangthai1 = "Request";
                var tgian = "";
                if (cv.ThoiGianHoanThanh != null) tgian = cv.ThoiGianHoanThanh.Value.ToString("yyyy-MM-dd");
                if (cv.TrangThai == trangthai)
                {
                    
                    CvCn.Add(new Job
                    {
                        Ten = cv.Ten,
                        ID = cv.ID,
                        ThoiGianHoanThanh = tgian,
                        File = cv.CongVanDinhKemCaNhan,
                        IDkhac = cv.CongViecPhong.Ten,
                        NoiDungCongViec = cv.NoiDungCongViec,
                        ThoiHanHoanThanh = cv.ThoiHanHoanThanh.Value.ToString("yyyy-MM-dd"),
                        IDNV = hoso.ID,
                        New = cv.New.ToString(),
                        TrangThai = cv.TrangThai.ToString(),
                        slPh = cv.PhanHois.Count,
                        PhanHoi = cv.NoiDungPhanHoi,
                        TrangThaiPh = th,
                        IDB=cv.IDCongViecPhong,
                        vitriCv=1
                    });
                    cv.New = 1;
                }
                    
            }
            db.SaveChanges();
            

            foreach (var cv in hoso.CongViecPhongs)
            {
                Job job = new Job();
                var th = 1;
                int slrequest = cv.CongViecCaNhans.Count(m => m.TrangThai == 2);
                if (cv.PhanHoi != null) th = cv.PhanHoi.Value;
                if (cv.TrangThai == trangthai)
                {
                    job = new Job
                    {
                        Ten = cv.Ten,
                        ID = cv.ID,
                        ThoiGianHoanThanh = cv.ThoiGianHoanThanh.Value.ToString("yyyy-MM-dd"),
                        File = cv.CongVanDinhKem,
                        IDkhac = cv.CongViec.Ten,
                        NoiDungCongViec = cv.NoiDungChitiet,
                        ThoiHanHoanThanh = cv.ThoiHanHoanThanh.Value.ToString("yyyy-MM-dd"),
                        IDNV = hoso.ID,
                        New = cv.New.ToString(),
                        TrangThai = cv.TrangThai.ToString(),
                        slPh = cv.PhanHoiCVs.Count,
                        PhanHoi = cv.NoiDungPhanHoi,
                        TrangThaiPh = th,
                        IDB = cv.IDCongViec,
                        vitriCv = 2,
                        slrequest=slrequest,
                        jobcn=cv.CongViecCaNhans.ToList()
                    };
                    cv.New = 1;
                    List<Job> jobs = new List<Job>();
                    foreach (var cvcn in CvCn)
                    {
                        if (cvcn.IDB == cv.ID)
                        {
                            jobs.Add(cvcn);
                        }
                    }
                    job.ListJobs = jobs;
                    CvPg.Add(job);
                }
                    
            }
            foreach (var cv in hoso.CongViecs)
            {
                var trangthai1 = "";
                var phooi = "";
                var th = 1;
                if (cv.PhanHoi != null) th = cv.PhanHoi.Value;
                if (cv.TrangThai == 2) trangthai1 = "Request";
                if (cv.TrangThai == trangthai)
                {

                    CvVt.Add(new Job
                    {
                        Ten = cv.Ten,
                        ID = cv.ID,
                        ThoiGianHoanThanh = cv.ThoiGianHoanThanh.Value.ToString("yyyy-MM-dd"),
                        File = cv.CongVanDinhKem,
                        NoiDungCongViec = cv.NoiDung,
                        ThoiHanHoanThanh = cv.NgayHoanThanh.Value.ToString("yyyy-MM-dd"),
                        IDNV = hoso.ID,
                        New = cv.New.ToString(),
                        TrangThai = cv.TrangThai.ToString(),
                        TrangThaiPh = th,
                        vitriCv = 4,
                        jobpg=cv.CongViecPhongs.ToList()
                    });
                    cv.New = 1;
                }

            }
            db.SaveChanges();
            List<Job> Cv = new List<Job>();
            if (maChucvu == 1) Cv = CvCn;
            else if (maChucvu == 2) Cv = CvPg;
            else if (maChucvu == 4) Cv = CvVt;
            return Cv;
        }
    }
}