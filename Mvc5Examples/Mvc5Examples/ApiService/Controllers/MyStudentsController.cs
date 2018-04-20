using Mvc5Examples.ApiService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mvc5Examples.ApiService.Controllers
{
    public class MyStudentsController : ApiController
    {
        //用C#数组定义可被Web API自动转换的JSON对象
        MyStudent[] students = new MyStudent[]
        {
            new MyStudent{ID="15001001", Name="张三", Grade=85},
            new MyStudent{ID="15001002", Name="李四", Grade=86},
            new MyStudent{ID="15001003", Name="王五", Grade=87}
        };

        //关键词：“Get...”或者“GetAll...”，其中“...”可以是任何名称
        public IEnumerable<MyStudent> GetAllStudents()
        {
            return students;
        }

        //关键词：Get...ById，其中“...”可以是任何名称
        public IHttpActionResult GetStudentById(string id)
        {
            var student = students.FirstOrDefault(p => p.ID == id);
            if (student == null)
            {
                //返回System.Web.Http.Results.NotFoundResult对象
                return NotFound();
            }
            //返回System.Web.Http.Results.OkNegotiatedContentResult对象
            return Ok(student);
        }
    }
}
