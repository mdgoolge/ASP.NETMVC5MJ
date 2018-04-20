using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Collections.Generic;
namespace Mvc5Examples.Areas.Chapter08.Models.MyDb2Model
{
    public class MyDb2 : DbContext
    {
        public MyDb2()
            : base("name=MyDb2")
        {
            //�����ã�ͨ��������ڹ۲����ݿ���������ݣ�
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
                .HasMany(e => e.MyTable3)      //MyTable2�е�1�ж�ӦMyTable3�еĶ���
                .WithRequired(e => e.MyTable2) //MyTable3�е�ѧ����MyTable2�б������
                //?���ü���ɾ����ɾ��MyTable2�еļ�¼ʱ�Զ�ɾ��MyTable3�ж�Ӧ�����м�¼��
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
