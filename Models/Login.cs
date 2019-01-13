using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KL.Models
{
    public class Login
    {
        public string userName { get; set; }

        public string passWord { get; set; }

        public bool rememberMe { get; set; }
    }
}