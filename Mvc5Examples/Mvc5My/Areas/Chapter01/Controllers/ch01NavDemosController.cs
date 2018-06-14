using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5My.Areas.Chapter01.Controllers
{
    public class ch01NavDemosController : Controller
    {
        // GET: Chapter01/ch01NavDemos
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