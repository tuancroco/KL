using KL.Models;
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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ClickLogin()
        {

            return PartialView();
        }
        public ActionResult ShowTaskPercent()
        {
            var listTask = new List<taskTimeModel>();
            listTask.Add(new taskTimeModel
            {
                jobName = "dao tao",
                percent = 80,
            });
            listTask.Add(new taskTimeModel
            {
                jobName = "khoa luan",
                percent = 15,
            });
            return View(listTask);
        }
    }
}