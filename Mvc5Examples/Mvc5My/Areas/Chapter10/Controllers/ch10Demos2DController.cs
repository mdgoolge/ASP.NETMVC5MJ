using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5My.Areas.Chapter10.Controllers
{
    public class ch10Demos2DController : Controller
    {

        public ActionResult Index(string id)
        {
            return PartialView(id);
        }

    }
}