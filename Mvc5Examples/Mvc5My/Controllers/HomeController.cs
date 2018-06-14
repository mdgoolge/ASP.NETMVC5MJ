using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5My.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult MainIndex()
        {
            ViewBag.Message = "ASP.NET MVC程序设计教程（第3版）";
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}