using Mvc5My.Areas.Chapter03.Models;
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



        // 例25～例30
        public ActionResult FormDemo(string id)
        {
            ViewBag.Result = "提示：单击提交按钮时将自动验证，请输入不同数据测试。";
            //初值为空是为了演示文本框中的水印效果
            MyUserModel user = new MyUserModel { UserName = "" };
            return PartialView(id, user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormDemo(string id, MyUserModel user)
        {
            ViewBag.Result = "数据验证失败，请输入有效的数据后再提交！";
            if (this.ModelState.IsValid)
            {
                //此处继续进一步验证，比如与数据库中的数据进一步比较……等
                //这里假设进一步验证失败，因此调用AddModelError继续添加错误消息
                if (user.UserName != "张三")
                {
                    //第1个参数为“键”，即MyUserModel.cs中定义的属性名
                    //第2个参数为与该键关联的错误信息
                    //添加的错误信息会自动显示在页面中
                    this.ModelState.AddModelError("UserName", "用户名不存在");
                }
                else
                {
                    //程序执行到此处，说明进一步验证也成功了。
                    //此时可继续处理成功提交的数据，比如将结果保存到数据库中等
                    ViewBag.Result = "数据提交成功！";
                }
            }
            return PartialView(id, user);
        }

        //例31～例32
        public ActionResult FormControlDemo(string id)
        {
            ViewBag.Result = "提示：按住<Ctrl>键可多选，单击提交按钮时将自动验证。";
            MyClass2Model c2 = new MyClass2Model();
            return PartialView(id, c2);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormControlDemo(string id, MyClass2Model c2)
        {
            ViewBag.Result = "数据验证失败，请输入有效的数据后再提交！";
            if (this.ModelState.IsValid)
            {
                string s = "数据提交成功！服务器接收的结果如下：";
                s += string.Format("\n性别：{0}", c2.Gender);
                s += "\n体育活动：";
                var sports = c2.MySports.Where(x => x.Value == true).ToList();
                s += string.Join("、", sports.Select(x => x.Key).ToArray());
                s += "\n常规业余活动：";
                s += string.Join("、", c2.MyExtDoings.ToArray());
                s += "\n最喜欢的业余活动：";
                s += string.Join("、", c2.MyFavExtDoings.ToArray());
                ViewBag.Result = s;
            }
            return PartialView(id, c2);
        }
    }
}