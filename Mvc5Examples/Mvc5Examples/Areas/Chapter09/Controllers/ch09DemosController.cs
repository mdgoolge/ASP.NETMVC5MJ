using Mvc5Examples.ApiService.Controllers;
using Mvc5Examples.StudentsService;
using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Mvc5Examples.Areas.Chapter09.Controllers
{
    public class ch09DemosController : Controller
    {
        //端口号是从主菜单的"项目"->"Mvc5Examples属性"中查到的
        private Uri uri = new Uri("http://localhost:3827/odata/");
        private Container container;
        public ch09DemosController()
        {
            container = new Container(uri);
        }

        public ActionResult Index(string id)
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView(id);
            }
            return View(id);
        }

        public ActionResult Demo3_GetStudents()
        {
            var model = container.Students.AsQueryable();
            return PartialView(model);
        }

        public ActionResult Other1_GetByID(string id)
        {
            try
            {
                var model = container.Students.Where(t => t.ID == id).SingleOrDefault();
                ViewBag.uri = container.BaseUri;
                return PartialView(model);
            }
            catch
            {
                return Content("未找到id为" + id + "的学生");
            }
        }

        public ActionResult Other2_Filter(int grade)
        {
            try
            {
                //系统会自动将where表达式转换为OData的$filter表达式
                var students = container.Students.Where(t => t.Grade >= grade);
                //也可以用下面的代码实现：
                //var students = from t in container.Students
                //               where t.Grade >= grade
                //               select t;

                return PartialView(students);
            }
            catch
            {
                return Content("未找到成绩大于等于" + grade + "的学生");
            }
        }
        public ActionResult Other3_OrderBy()
        {
            //container会自动将OrderBy表达式转换为OData的$orderby表达式
            var students = container.Students.OrderByDescending(t => t.Grade);
            return PartialView(students);
        }
        public ActionResult Other4_Paging()
        {
            //container会自动将其转换为OData的$skip和$top表达式
            var students = container
                .Students.OrderBy(t => t.Grade)
                .Skip(3).Take(3);  //跳过3条记录然后取3条记录
            return PartialView(students);
        }

        public ActionResult Other5_Create()
        {
            var maxID = container.Students.AsEnumerable().Max(t => t.ID);
            var newID = (int.Parse(maxID) + 1).ToString();
            Student student = new Student
            {
                ID = newID,
                Name = "A" + newID,
                Grade = 97
            };
            List<string> result = new List<string>();
            result.Add(string.Format(
                "添加的记录：ID:{0}，Name:{1}，Grade:{2}",
                student.ID, student.Name, student.Grade));
            try
            {
                container.AddToStudents(student);
                var serviceResponse = container.SaveChanges();
                ShowResponseStatusCode(result, serviceResponse);
            }
            catch (Exception ex)
            {
                result.Add(ex.Message + "：" + ex.InnerException.Message);
            }
            return PartialView(result);
        }

        public ActionResult Other6_Update(string id, int grade)
        {
            List<string> result = new List<string>();
            result.Add(string.Format("将学号为{0}的成绩修改为{1}", id, grade));
            try
            {
                var student = container.Students.Where(t => t.ID == id).SingleOrDefault();
                if (student != null)
                {
                    student.Grade = grade;
                    container.UpdateObject(student);
                    var serviceResponse = container.SaveChanges(System.Data.Services.Client.SaveChangesOptions.PatchOnUpdate);
                    ShowResponseStatusCode(result, serviceResponse);
                }
            }
            catch (Exception ex)
            {
                result.Add(ex.Message + "：" + ex.InnerException.Message);
            }
            return PartialView(result);
        }

        public ActionResult Other7_Delete(string id)
        {
            List<string> result = new List<string>();
            result.Add(string.Format("删除学号为{0}的记录", id));
            try
            {
                var student = container.Students.Where(t => t.ID == id).SingleOrDefault();
                if (student != null)
                {
                    container.DeleteObject(student);
                    var serviceResponse = container.SaveChanges();
                    ShowResponseStatusCode(result, serviceResponse);
                }
            }
            catch (Exception ex)
            {
                result.Add(ex.Message + "：" + ex.InnerException.Message);
            }
            return PartialView(result);
        }

        public ActionResult Init()
        {
            List<string> result = new List<string>();
            result.Add("删除所有记录，然后初始化测试记录。");
            try
            {
                var students = container.Students;
                foreach (var v in students)
                {
                    container.DeleteObject(v);
                }
                var t = new List<Student>
                {
                    new Student{ ID = "15001001", Name="张三", Grade=90 },
                    new Student{ ID = "15001002", Name="李四", Grade=91 },
                    new Student{ ID = "15001003", Name="王五", Grade=92 },
                    new Student{ ID = "15001004", Name="赵六一", Grade=93 },
                    new Student{ ID = "15001005", Name="赵六二", Grade=94 },
                    new Student{ ID = "15001006", Name="赵六三", Grade=95 },
                    new Student{ ID = "15001007", Name="赵六四", Grade=96 }
                };
                t.ForEach(v => container.AddToStudents(v));
                var serviceResponse = container.SaveChanges();
                ShowResponseStatusCode(result, serviceResponse);

            }
            catch (Exception ex)
            {
                result.Add(string.Format("{0}：{1}",
                    ex.Message,
                    ex.InnerException.Message));
            }
            return PartialView(result);
        }

        private void ShowResponseStatusCode(List<string> result, DataServiceResponse r)
        {
            result.Add("服务器返回的HTTP响应状态：");
            foreach (var v in r)
            {
                result.Add("状态码：" + v.StatusCode);
            }
        }
    }
}