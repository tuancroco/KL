using KL.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KL.Models
{
    public class DataChanges
    {
        public  void changeReport(string hsId,string idJob)
        {
            var db = new Smof();
            db.CongViecCaNhans.Where(m => m.ID == idJob).FirstOrDefault().TrangThai = 3;
            db.SaveChanges();
        }
    }
}