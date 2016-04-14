using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorks.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Us Page";

            return View();
        }

        public ActionResult ContactUs()
        {
            ViewBag.Message = "Contact Us Page";

            return View();
        }
    }
}