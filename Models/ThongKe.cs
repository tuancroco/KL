﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KL.Models
{
    public class ThongKe
    {
        public DateTime fromdate { get; set; }
        public DateTime todate { get; set; }
        public int ttCv { get; set; }
        public int loaiCv { get; set; }
    }
}