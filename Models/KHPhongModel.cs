using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KL.Models
{
    public class CaNhanModel
    {
        public string Ten { get; set; }
        public string Noidung { get; set; }
        public string IDHs { get; set; }
        public string DeadLine { get; set; }
    }
    public class KhPhongModel
    {
        public List<CaNhanModel> newPlans {get;set;}
        public string ID { get; set; }
    }
}