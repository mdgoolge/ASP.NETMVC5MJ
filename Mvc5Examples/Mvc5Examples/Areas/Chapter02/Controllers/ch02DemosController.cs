using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5Examples.Areas.Chapter02.Controllers
{
    public class ch02DemosController : Controller
    {
        //例1和例5之外的其他例子
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

        //例1
        public ActionResult Welcome()
        {
            var id = RouteData.Values["id"].ToString();
            var name = Request["name"];
            var age = Request["age"];
            var url = Request.Url;
            string s = "";
            if (id == "1")
            {
                s = string.Format("欢迎，你的id为：{0}\n访问的URL为：{1}", id, url);
            }
            else if (id == "2")
            {
                s = string.Format(
                    "欢迎你,{0}，\n访问的URL为：{1}\n\n" +
                    "地址栏中的“{2}”为自动对参数“{0}”进行URL编码后的结果。",
                    name, url, Server.UrlEncode(name));
            }
            else
            {
                s = string.Format(
                    "欢迎你,{0}岁的{1}，\n访问的URL为：{2}\n\n" +
                    "地址栏中的“{3}”为自动对参数“{1}”进行URL编码后的结果。",
                    age, name, url, Server.UrlEncode(name));
            }
            ViewBag.Message = s;
            return View();
        }

        //例5
        public ActionResult Ajax1()
        {
            string s = string.Format("{0:HH:mm:ss}", DateTime.Now);
            return Content(s);
        }
    }
}