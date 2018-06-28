namespace Mvc5My.ApiService.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class MyDb3 : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“MyDb3”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“Mvc5My.ApiService.Models.MyDb3”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“MyDb3”
        //连接字符串。
        public MyDb3()
            : base("name=MyDb3")
        {
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

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