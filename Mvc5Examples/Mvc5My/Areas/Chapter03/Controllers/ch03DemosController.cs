using Mvc5My.Areas.Chapter03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5My.Areas.Chapter03.Controllers
{
    public class ch03DemosController : Controller
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

        public ActionResult ContentResultDemo1()
        {
            string s = string.Format("返回结果：{0:HH:mm:ss}", DateTime.Now);
            return Content(s);
        }

        public ActionResult ContentResultDemo2()
        {
            string s = "alert('Hello');";
            return Content(s, "text/javascript");
        }
        public ActionResult JavaScriptResultDemo()
        {
            return JavaScript("alert('hello')");
        }

        [HttpPost ]
        public ActionResult JsonResultDemo1()
        {
            string s = string.Format("返回结果：{0:HH::mm:ss}", DateTime.Now);
            return Json(s);
        }

        [HttpPost]
        public ActionResult JsonResultDemo2()
        {
            MyColorModel colorName = new MyColorModel { EnglishName = "red", ChineseName = "红色" };
            return Json(colorName);
        }
        public ActionResult FileResultDemo()
        {
            var downloadFile = File("~/Areas/Chapter03/downloadFiles/a1.docx", "application/vnd.ms-word", "阿斯蒂芬.docx");
            return downloadFile;
        }
        public ActionResult FileContentResultDemo()
        {
            byte[] fileContents = System.IO.File.ReadAllBytes(
                    Server.MapPath("~/Areas/Chapter03/downloadFiles/a1.docx"));
            return File(fileContents, "application/vnd.ms-word", "asdf.docx");
        }
        public ActionResult FileStreamResultDemo()
        {
            byte[] fileContents = System.IO.File.ReadAllBytes(
                    Server.MapPath("~/Areas/Chapter03/downloadFiles/a1.rar"));
            var fileStream = new System.IO.MemoryStream(fileContents);

            return File(fileStream, "application/vnd.ms-word", "asdf.rar");
        }
        public ActionResult RedirectResultDemo()
        {
            string url = Url.Action("Index", "ch03Demos", new { id = "ActionRendAction" });

            return Redirect(url);
        }
        public ActionResult ShowHello(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Content(string.Format("Hello，今天是{0:dddd}", DateTime.Now));
            }
            else
            {
                ViewBag.Message = "欢迎您，" + Server.HtmlEncode(name);
                return PartialView();
            }
        }
        public ActionResult ViewDataViewBag()
        {
            //单个数据
            ViewData["Name"] = "张三";
            ViewBag.Name = "张三";

            //多个数据
            List<string> myColors = new List<string>
            {
                "red,红色", "green,绿色", "blue,蓝色"
            };
            ViewData["MyColors"] = myColors;
            ViewBag.MyColors = myColors;

            return PartialView();
        }

        //例3
        public ActionResult ServerDemo()
        {
            var str = "<hello>,张三";
            ViewBag.Str = str;
            ViewBag.HtmlEncodeStr = Server.HtmlEncode(str);
            ViewBag.HtmlDecodeStr = Server.HtmlDecode(str);
            ViewBag.UrlEncodeStr = Server.UrlEncode(str);
            ViewBag.UrlDecodeStr = Server.UrlDecode(str);
            ViewBag.MapPath1 = Server.MapPath("~/Common/images");
            ViewBag.MapPath2 = Server.MapPath("Common/images");
            return PartialView();
        }  
        
        //例4
        public ActionResult RequestDemo()
        {
            string s = "";
            s += string.Format("<p>请求的URL：{0}</p>", Request.Url);
            string filePath = Request.FilePath;
            s += string.Format("<p>相对路径：{0}</p>", filePath);
            s += string.Format("<p>完整路径：{0}</p>", Request.MapPath(filePath));
            s += string.Format("<p>HTTP请求类型：{0}</p>", Request.RequestType);
            ViewBag.Result = MvcHtmlString.Create(s);
            return PartialView();
        }
    }
}