using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5My.Areas.Chapter05.Controllers
{
    public class ch05DemosController : Controller
    {
        //ch05Index.cshtml调用的操作方法
        public ActionResult Index(string id)
        {
            return View(id);
        } 
        
        //例1～例14、例21、例23～例24
        public ActionResult Index1(string id)
        {
            return PartialView(id);
        }
    }
}