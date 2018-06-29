using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5My.Areas.Chapter10.Controllers
{
    public class ThreejsExamplesController : Controller
    {
        public ActionResult aIndex(string id)
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