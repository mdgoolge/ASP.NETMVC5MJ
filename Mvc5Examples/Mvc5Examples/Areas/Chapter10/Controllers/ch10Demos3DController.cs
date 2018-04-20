using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5Examples.Areas.Chapter10.Controllers
{
    public class ch10Demos3DController : Controller
    {
        public ActionResult Index3d(string id)
        {
            ViewBag.src = id;
            return PartialView();
        }

        public ActionResult Rend3dScene(string src)
        {
            return View(src);
        }
    }
}