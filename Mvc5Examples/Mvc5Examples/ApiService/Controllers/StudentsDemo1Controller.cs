using Mvc5Examples.ApiService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mvc5Examples.ApiService.Controllers
{
    public class StudentsDemo1Controller : ApiController
    {
        //9.2.1（1.用C#数组定义JSON对象）的代码片段示例
        Student[] students = new Student[]
        {
            new Student{ID="15001001", Name="张三", Grade=85},
            new Student{ID="15001002", Name="李四", Grade=86},
            new Student{ID="15001003", Name="王五", Grade=87}
        };

        //用法1（默认约定：调用时仅查找Http请求的前缀，而与方法名中该前缀后的内容无关）
        //可用的常用前缀有：Get、GetAll、Post、Create、Put、Delete等，前缀不区分大小写
        //优点：不需要添加Route声明
        //缺点：要求开发人员必须记住有哪些类型的请求前缀
        //命名约定：Get...、GetAll...，其中“...”可以是任何名称
        //例如：GetAllStudents、GetAllaaa等，结果都一样
        public IEnumerable<Student> GetAllStudents()
        {
            return students;
        }

        //用法2（用Route声明Http请求的方法，调用时不需要去掉前缀）
        //优点：直观、灵活
        //缺点：需要对每个方法都添加Route声明
        //下面的方法如果不添加Route声明，需要去掉"Get"，即通过MyStudents调用这个方法
        //添加Route声明后，就可以直接通过GetMyStudents调用这个方法
        //[Route("api/GetMyStudents")]
        //public IEnumerable<Student> GetMyStudents()
        //{
        //    return students;
        //}

        //默认的命名约定：Get...ById，其中“...”可以是任何名称
        //按命名约定定以后，WebApi会自动在路由字典中匹配相应的Action
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
