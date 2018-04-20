using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

//OData的例子用
namespace Mvc5Examples.ApiService.Models
{
    public class MyDb3 : DbContext
    {
        public MyDb3()
            : base("name=MyDb3")
        {
            //调试用（通过输出窗口观察数据库操作的内容）
            //this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
        public DbSet<Student> Student { get; set; }
    }
    public class StudentsInitialize : DropCreateDatabaseIfModelChanges<MyDb3>
    {
        //设置数据库种子
        protected override void Seed(MyDb3 context)
        {
            var t = new List<Student>
            {
                new Student{ ID = "15001001", Name="张三", Grade=90 },
                new Student{ ID = "15001002", Name="李四", Grade=91 },
                new Student{ ID = "15001003", Name="王五", Grade=92 },
                new Student{ ID = "15001004", Name="赵六一", Grade=93 },
                new Student{ ID = "15001005", Name="赵六二", Grade=94 },
                new Student{ ID = "15001006", Name="赵六三", Grade=95 },
                new Student{ ID = "15001007", Name="赵六四", Grade=96 },
            };
            t.ForEach(v => context.Student.Add(v));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}