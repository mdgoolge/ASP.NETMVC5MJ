using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5Examples.Areas.Chapter06.Controllers
{
    public class ch06DemosController : Controller
    {
        //ch06Index.cshtml调用的操作方法
        public ActionResult Index(string id)
        {
            return View(id);
        }

        //本章示例调用的操作方法
        public ActionResult Index1(string id)
        {
            return PartialView(id);
        }
    }
}