using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5Examples.Areas.Chapter01.Controllers
{
    public class ch01NavDemosController : Controller
    {
        public ActionResult Index(string id)
        {
            return View(id);
        }

        public ActionResult LayoutDemo(string id)
        {
            return View(id);
        }
    }
}