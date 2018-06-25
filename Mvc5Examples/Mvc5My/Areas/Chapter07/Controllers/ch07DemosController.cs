using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5My.Areas.Chapter07.Controllers
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
    }
}