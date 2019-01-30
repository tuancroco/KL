using KL.Models;
using KL.Models.DatabaseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
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
        public static string userId = "";
        public ActionResult SaveNew(KhPhongModel kh)
        {
            if (kh.newPlans[0].Ten == null) return RedirectToAction("Login", "Login");
            var IDCVPhong = kh.ID;

            db.CongViecPhongs.Where(m => m.ID == IDCVPhong).FirstOrDefault().TrangThai = 1;
            db.SaveChanges();
            var IDNhanSu = db.HoSoNhanSus.Where(m => m.CongViecPhongs.Any(n => n.ID == kh.ID)).FirstOrDefault().ID;
            var hoso = db.HoSoNhanSus.Where(m => m.ID == IDNhanSu).FirstOrDefault();
            var id = (db.CongViecCaNhans.ToList().Count);
            var newPlans = kh.newPlans;
            foreach(var item in newPlans)
            {
                id++;
                var hoSoNhanSu = db.HoSoNhanSus.Where(m => m.ID == item.IDHs).FirstOrDefault();
                DateTime result = DateTime.ParseExact(item.DeadLine, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var CvCanhan = new CongViecCaNhan()
                {
                    ID = id.ToString(),
                    Ten=item.Ten,
                    ThoiHanHoanThanh=result,
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
        public ActionResult Report(string idJob,int ma)
        {
            string hsId = "";
            var db = new Smof();
            if (ma == 1)
            {
                db.CongViecCaNhans.Where(m => m.ID == idJob).FirstOrDefault().TrangThai = 2;
                db.CongViecCaNhans.Where(m => m.ID == idJob).FirstOrDefault().New = 0;
                hsId = db.HoSoNhanSus.Where(m => m.CongViecCaNhans.Any(n => n.ID == idJob)).First().ID;
            }
            else
            {
                db.CongViecPhongs.Where(m => m.ID == idJob).FirstOrDefault().TrangThai = 2;
                db.CongViecPhongs.Where(m => m.ID == idJob).FirstOrDefault().New = 0;
                hsId = db.HoSoNhanSus.Where(m => m.CongViecPhongs.Any(n => n.ID == idJob)).First().ID;
            }
            
            db.SaveChanges();
            return RedirectToAction("Login","Login");
        }
        public ActionResult SendRequest(string idJob,string request,int ma)
        {
            var db = new Smof();
            if (ma == 2)
            {
                if (request == "")
                {
                    db.CongViecCaNhans.Where(m => m.ID == idJob).FirstOrDefault().TrangThai = 5;
                    db.CongViecCaNhans.Where(m => m.ID == idJob).FirstOrDefault().PhanHoi = 0;
                    db.CongViecCaNhans.Where(m => m.ID == idJob).FirstOrDefault().NoiDungPhanHoi = "Done";
                }
                else
                {
                    db.CongViecCaNhans.Where(m => m.ID == idJob).FirstOrDefault().TrangThai = 5;
                    var cncn = db.CongViecCaNhans.Where(m => m.ID == idJob).FirstOrDefault();
                    db.CongViecCaNhans.Where(m => m.ID == idJob).FirstOrDefault().PhanHoi = 1;
                    db.CongViecCaNhans.Where(m => m.ID == idJob).FirstOrDefault().New = 0;
                    var idtp = db.HoSoNhanSus.Where(m => m.CongViecCaNhans.Any(n => n.ID == idJob)).First().ID;
                    var Id = 0;
                    if (db.PhanHois != null)
                        Id = (db.PhanHois.ToList().Count) + 2;
                    PhanHoi ph = new PhanHoi
                    {
                        ID = Id.ToString(),
                        NoiDung = request,
                        IDCongviecCaNhan = idJob,
                        IDTruongPhong = idtp,
                        TrangThai = 0,
                        Datecreate = DateTime.Now
                    };
                    db.PhanHois.Add(ph);
                    db.CongViecCaNhans.Where(m => m.ID == idJob).FirstOrDefault().PhanHoi = 0;
                    db.CongViecCaNhans.Where(m => m.ID == idJob).FirstOrDefault().NoiDungPhanHoi = request;
                }
            }
            else
            {
                if (request == "")
                {
                    db.CongViecPhongs.Where(m => m.ID == idJob).FirstOrDefault().TrangThai = 3;
                    db.CongViecPhongs.Where(m => m.ID == idJob).FirstOrDefault().New = 0;
                }
                else
                {
                    var cncn = db.CongViecPhongs.Where(m => m.ID == idJob).FirstOrDefault();
                    db.CongViecPhongs.Where(m => m.ID == idJob).FirstOrDefault().PhanHoi = 1;
                    db.CongViecPhongs.Where(m => m.ID == idJob).FirstOrDefault().New = 0;
                    var Id = 0;
                    if (db.PhanHois != null)
                        Id = (db.PhanHoiCVs.ToList().Count) + 2;
                    PhanHoiCV ph = new PhanHoiCV
                    {
                        ID = Id.ToString(),
                        Noidung = request,
                        IDCongviecPhong = idJob,
                        TrangThai = 0,
                        Datecreate = DateTime.Now
                    };
                    db.PhanHoiCVs.Add(ph);
                    db.CongViecPhongs.Where(m => m.ID == idJob).FirstOrDefault().PhanHoi = 0;
                    db.CongViecPhongs.Where(m => m.ID == idJob).FirstOrDefault().NoiDungPhanHoi = request;
                }
            }
            
            
            db.SaveChanges();
            return View();
        }
        public ActionResult GetPHoi(string idJob)
        {
            db = new Smof();

            var phahois = db.PhanHois.Where(m => m.IDCongviecCaNhan == idJob).OrderByDescending(m=>m.Datecreate);

            return View(phahois.ToList());
        }
        public ActionResult NewJob(string pb,string tp,string nd,string ten,string tg,string file)
        {
            var db = new Smof();
            CongViec cv = new CongViec();
            var id = db.CongViecs.Count() + 1;
            cv.CongVanDinhKem = file;
            cv.Datecreate = DateTime.Now;
            cv.NoiDung = nd;
            cv.TrangThai = 1;
            cv.ID = id.ToString();
            CongViecPhong cvp = new CongViecPhong();
            var idp = db.CongViecPhongs.Count() + 1;
            cvp.ID = idp.ToString();
            cvp.NoiDungChitiet = nd;
            cvp.CongVanDinhKem = file;
            cvp.Datecreate = DateTime.Now;
            cvp.IDHoSoNhanSuPhuTrach = tp;
            cvp.ThoiHanHoanThanh = (DateTime)DateTime.ParseExact(tg, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            cvp.New = 0;
            cvp.TrangThai = 0;
            cvp.Ten = ten;
            cvp.IDCongViec = id.ToString();
            db.CongViecs.Add(cv);
            db.CongViecPhongs.Add(cvp);
            db.SaveChanges();
            return RedirectToAction("Login", "Login");
        }
        public ActionResult UploadFiles(HttpPostedFileBase file,string jobId)
        {

            
            return RedirectToAction("Login", "Login");
        }
        [HttpPost]
        public ActionResult UploadFile()
        {
            // Checking no of files injected in Request object  
            
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {

                        HttpPostedFileBase file = files[i];
                        string fname;
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }
                        var t = Request.Form["jobId"];
                        var ma = Request.Form["ma"];
                        fname = Path.Combine(Server.MapPath("~/Uploads/"), fname);
                        var db = new Smof();
                        if (ma == "1")
                        {
                            if (t == "") t = (db.CongViecCaNhans.Count()).ToString();

                            if (Request.Form.AllKeys.Contains("congvan"))
                            {
                                db.CongViecCaNhans.Where(m => m.ID == t).First().CongVanDinhKemCaNhan = fname.ToString();
                            }
                            else
                            {
                                db.CongViecCaNhans.Where(m => m.ID == t).First().upload = fname.ToString();
                            }
                        }
                        else if(ma=="2")
                        {
                            if (t == "") t = (db.CongViecPhongs.Count()).ToString();

                            if (Request.Form.AllKeys.Contains("congvan"))
                            {
                                db.CongViecPhongs.Where(m => m.ID == t).First().CongVanDinhKem = fname.ToString();
                            }
                            else
                            {
                                db.CongViecPhongs.Where(m => m.ID == t).First().upload = fname.ToString();
                            }
                        }
                        
                        
                        db.SaveChanges();
                        file.SaveAs(fname);
                        
                    }
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }
        public ActionResult Downloads()
        {
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/downloads/"));
            System.IO.FileInfo[] fileNames = dir.GetFiles("*.*");
            List<string> items = new List<string>();
            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }
            return View(items);
        }
        public FileResult Download()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(@"c:\folder\myfile.ext");
            string fileName = "myfile.ext";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}