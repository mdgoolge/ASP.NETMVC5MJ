using Mvc5Examples.Areas.Chapter03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5Examples.Areas.Chapter03.Controllers
{
    public class ch03NavDemosController : Controller
    {
        //例10（将.NET框架提供的类转换为模型）
        public ActionResult ModelDemo1()
        {
            List<string> list = new List<string>
            {
                "red,红色", "green,绿色", "blue,蓝色"
            };
            return PartialView(list);
        }

        //例11（自定义模型--单个数据）
        public ActionResult ModelDemo2()
        {
            MyColorModel myColor = new MyColorModel { EnglishName = "red", ChineseName = "红色" };
            return PartialView(myColor);
        }

        //例12（自定义模型--多个数据）
        public ActionResult ModelDemo3()
        {
            List<MyStudentModel> students = new List<MyStudentModel>
            {
                new MyStudentModel{XueHao = "001",XingMing = "张三",XingBie = "男",NianLing = 20 },
                new MyStudentModel{XueHao = "002",XingMing = "李四",XingBie = "男",NianLing = 23 },
                new MyStudentModel{XueHao = "003",XingMing = "王五",XingBie = "男",NianLing = 21 },
            };
            return PartialView(students);
        }

        //例13（客户端验证）
        public ActionResult Validation1(MyStudentModel student)
        {
            if (Request.HttpMethod == "GET")
            {
                student = new MyStudentModel
                {
                    XueHao = "01", XingMing = "张", NianLing = 3
                };
                return PartialView(student);
            }
            else
            {
                return JavaScript("alert('数据已提交！')");
            }
        }

        //例14（服务器验证）
        public ActionResult Validation2(MyUserModel user)
        {
            if (Request.HttpMethod == "GET")
            {
                user = new MyUserModel();
            }
            else
            {
                if (this.ModelState.IsValid)
                {
                    string s = "服务器验证成功！提交结果：";
                    s += string.Format(
                        "用户Id：{0}，用户名：{1}，年龄：{2}，出生日期：{3}",
                        user.UserId, user.UserName, user.Age, user.BirthDate);
                    ViewBag.Result = s;
                }
            }
            return PartialView(user);
        }
    }
}