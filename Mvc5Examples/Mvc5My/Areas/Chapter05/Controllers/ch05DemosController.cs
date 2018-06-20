using Mvc5My.Areas.Chapter05.Models;
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

        //例15
        public ActionResult HttpGetDemo()
        {
            ViewBag.UserName = Request["text1"];
            ViewBag.Age = Request["text2"];
            return View();
        }

        //例16
        public ActionResult HttpPostDemo()
        {
            if (Request.HttpMethod == "POST")
            {
                ViewBag.UserName = Request.Form["text1"];
                ViewBag.Age = Request.Form["text2"];
            }
            else
            {
                ViewBag.UserName = "张三";
                ViewBag.Age = 23;
            }
            return View();
        }

        //例17
        public ActionResult HtmlBeginForm(MyClass1Model c1)
        {
            if (Request.HttpMethod == "GET")
            {
                c1 = new MyClass1Model { n1 = 3, n2 = 5 };
                ViewBag.Result = "";
            }
            else
            {
                ViewBag.Result = string.Format("n1={0}, n2={1}", c1.n1, c1.n2);
            }
            return View(c1);
        }

        //例18
        public ActionResult AjaxBeginForm(MyClass1Model c1)
        {
            if (Request.HttpMethod == "GET")
            {
                c1 = new MyClass1Model { n1 = 3, n2 = 5 };
                ViewBag.Result = "";
            }
            else
            {
                ViewBag.Result = string.Format("n1={0}, n2={1}", c1.n1, c1.n2);
            }
            return PartialView(c1);
        }


        //例19
        public ActionResult inputDemo()
        {
            ViewBag.Result = "等待提交数据。";
            if (Request.HttpMethod == "POST")
            {
                if (this.ModelState.IsValid)
                {
                    ViewBag.Result = "数据已提交。";
                }
                else
                {
                    ViewBag.Result = "数据验证失败。";
                }
            }
            return PartialView();
        }


        //例20
        public ActionResult buttonDemo1(MyClass1Model c1)
        {
            if (Request.HttpMethod == "GET")
            {
                c1 = new MyClass1Model { n1 = 3, n2 = 5 };
            }
            else
            {
                string btn = Request["btn"];
                ViewBag.result = "（服务器响应）你单击的按钮是：" + btn;
            }
            return PartialView(c1);
        }
        //例22
        public ActionResult ButtonDemo3(MyClass1Model c1)
        {
            string result = "";
            if (Request.HttpMethod == "GET")
            {
                c1 = new MyClass1Model();
                c1.n1 = 3;
                c1.n2 = 5;
            }
            else if (this.ModelState.IsValid)
            {
                string btn = Request["btn"];
                switch (btn)
                {
                    case "求和":
                        result = string.Format("{0} + {1} = {2}",
                            c1.n1, c1.n2, c1.n1 + c1.n2);
                        break;
                    case "求积":
                        result = string.Format("{0} × {1} = {2}",
                            c1.n1, c1.n2, c1.n1 * c1.n2);
                        break;
                }
            }
            ViewBag.result = result;
            return PartialView(c1);
        }





    }
}