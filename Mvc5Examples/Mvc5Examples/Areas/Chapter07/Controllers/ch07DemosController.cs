using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5Examples.Areas.Chapter07.Controllers
{
    public class ch07DemosController : Controller
    {
        public ActionResult Index(string id)
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView(id);
            }
            else
            {
                return View(id);
            }
        }

        public ActionResult jqueryMenu2(string item)
        {
            ViewBag.MenuItem = item;
            return View();
        }

        public ActionResult Menu(string item)
        {
            ViewBag.MenuItem = item;
            return View();
        }


        public ActionResult progressBarExample(int p)
        {
            if (p < 2) p = 2;
            progress(p);
            return View();
        }
        private void progress(int k)
        {
            for (int i = 0; i <= 100; i++)
            {
                System.Threading.Thread.Sleep(100);
                if (i >= k)
                {
                    ViewBag.Progress = i + "%";
                    return;
                }
            }
        }
    }
}