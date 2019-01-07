using System;
using System.Collections.Generic;
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
        public ActionResult CreateNew()
        {
            return View();
        }
    }
}