using Mvc5My.StudentsService;
using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5My.Areas.Chapter09.Controllers
{
    public class ch09DemosController : Controller
    {
        private Uri uri = new Uri("http://localhost:2319/odata/");
        private Container container;
        public ch09DemosController()
        {
            string url = HttpContext.Request.Url.ToString();
            
            //container = new Container(uri);
        }

        public ActionResult Index(string id)
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView(id);
            }
            return View(id);
        }

        public ActionResult Demo3()
        {
            ContainerCreate();

            var model = container.Students.AsQueryable();
            ViewBag.uri = uri.ToString();
            return PartialView(model);
        }


        public ActionResult Init()
        {

            ContainerCreate();

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

        /// <summary>
        /// 在构造函数里request还没有成绩，为null，所以要在Action里调用时创建
        /// </summary>
        private void ContainerCreate()
        {
            if (container != null)
            {
                return;
            }

            string url = string.Format("http://{0}/odata/", Request.Url.Authority);

            uri = new Uri(url);
            container = new Container(uri);
        }
        private void ShowResponseStatusCode(List<string> result, DataServiceResponse r)
        {
            result.Add("服务器返回的HTTP响应状态：");
            foreach (var v in r)
            {
                result.Add("状态码：" + v.StatusCode);
            }
        }

        public ActionResult Other1_GetByID(string id)
        {
            try
            {
                ContainerCreate();


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
                ContainerCreate();
                var students = container.Students.Where(t => t.Grade >= grade);
                //students = from t in container.Students
                //           where t.Grade >= grade
                //           select t;
                return PartialView(students);
            }
            catch
            {
                return Content("未找到成绩大于等于" + grade + "的学生");
            }
        }
        public ActionResult Other3_OrderBy()
        {
            try
            {
                ContainerCreate();

                var students = container.Students.OrderByDescending(t => t.Grade);

                return PartialView(students);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public ActionResult Other4_Paging()
        {
            try
            {
                ContainerCreate();

                var students = container
                    .Students
                    .OrderBy(t => t.Grade)
                    .Skip(3).Take(3);//跳过3条记录然后取3条记录

                return PartialView(students);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        public ActionResult Other5_Create()
        {
                ContainerCreate();

                var maxid = container.Students.AsEnumerable().Max(t => t.ID);
                var newid = (int.Parse(maxid) + 1).ToString();
                Student news = new Student
                {
                    ID = newid,
                    Name = "A" + newid,
                    Grade = 97
                };
                List<string> result = new List<string>();
                result.Add(string.Format(
                    "添加的记录:ID:{0},Name:{1},Grade:{2}",
                    news.ID, news.Name, news.Grade));
            
            try
            {
                container.AddToStudents(news);
                var serviceresponse = container.SaveChanges();
                ShowResponseStatusCode(result, serviceresponse);

            }
            catch (Exception ex)
            {
                result.Add(ex.Message + ":" + ex.InnerException.Message);
            }
            return PartialView(result);
        }










    }
}