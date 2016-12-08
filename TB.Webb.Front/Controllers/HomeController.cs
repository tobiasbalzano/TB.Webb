using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TB.Webb.Front.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Title";
            ViewBag.Custom = "Custom";
            return View(ViewBag);
        }
    }
}