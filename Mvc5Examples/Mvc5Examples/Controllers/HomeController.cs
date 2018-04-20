using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5Examples.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult MainIndex()
        {
            ViewBag.Message = "ASP.NET MVC程序设计教程（第3版）";
            return View();
        }

        public ActionResult emulator()
        {
            return View();
        }


        //以下是模板默认生成的操作方法（_Layout.cshtml文件用）
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