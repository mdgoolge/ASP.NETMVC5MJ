namespace Mvc5My.Areas.Chapter08.Models.MyDb2Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MyDb2 : DbContext
    {
        public MyDb2()
            : base("name=MyDb2")
        {
            //调试用（通过输出窗口观察数据库操作的内容）
            //this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
        public virtual DbSet<MyTable1> MyTable1 { get; set; }
        public virtual DbSet<MyTable2> MyTable2 { get; set; }
        public virtual DbSet<MyTable3> MyTable3 { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyTable1>()
                .Property(e => e.KeChengID)
                .IsFixedLength();

            modelBuilder.Entity<MyTable1>()
                .HasMany(e => e.MyTable3)
                .WithRequired(e => e.MyTable1)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<MyTable2>()
                .Property(e => e.StudentID)
                .IsFixedLength();

            modelBuilder.Entity<MyTable2>()
                .HasMany(e => e.MyTable3)      //MyTable2中的1行对应MyTable3中的多行
                .WithRequired(e => e.MyTable2) //MyTable3中的学号在MyTable2中必须存在
                //?启用级联删除（删除MyTable2中的记录时自动删除MyTable3中对应的所有记录）
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<MyTable3>()
                .Property(e => e.StudentID)
                .IsFixedLength();

            modelBuilder.Entity<MyTable3>()
                .Property(e => e.KeChengID)
                .IsFixedLength();
        }
    }
}