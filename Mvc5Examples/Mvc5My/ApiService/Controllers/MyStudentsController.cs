using Mvc5My.ApiService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mvc5My.ApiService.Controllers
{
    public class MyStudentsController : ApiController
    {
        MyStudent[] students = new MyStudent[]
        {
            new   MyStudent{ID="15001001",Name="张三",Grade=85},
            new   MyStudent{ID="15001002",Name="李四",Grade=85},
            new   MyStudent{ID="15001003",Name="王五",Grade=85}
        };

        public IEnumerable<MyStudent> GetAllStudents()
        {
            return students;
        }

        public IHttpActionResult GetStudentById(string id)
        {
            var student = students.FirstOrDefault(p => p.ID == id);
            if (student==null)
            {
                return NotFound();
            }

            return Ok(student);
        }
    }
}
