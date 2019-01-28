using KL.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KL.Models
{
    public class Job
    {
        public string Ten { get; set; }
        public string ID { get; set; }
        public string ThoiGianHoanThanh { get; set; }
        public string File { get; set; }
        public string NoiDungCongViec { get; set; }
        public string IDkhac { get; set; }
        public string ThoiHanHoanThanh { get; set; }
        public List<Job> ListJobs { get; set; }
        public string IDNV { get; set; }
        public string TrangThai { get; set; }
        public string PhanHoi { get; set; }
        public string New { get; set; }
        public List<PhanHoiRequest> ListPhanHoi { get; set; }
        public int slPh { get; set; }
        public int TrangThaiPh { get; set; }
        public string IDB { get; set; }
        public int vitriCv { get; set; }
        public int slrequest { get; set; }
        public List<CongViecCaNhan> jobcn { get; set; }
        public List<CongViecPhong> jobpg { get; set; }
    }
    public class PhanHoiRequest
    {
        public string ID { get; set; }
        public string IDB { get; set; }
        public string IDS { get; set; }
        public string NoiDung { get; set; }
        public string New { get; set; }
        public string date { get; set; }
    }
}

                                   