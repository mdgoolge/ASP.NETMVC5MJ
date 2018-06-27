namespace Mvc5My.Models.MyDb1Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDb1 : DbContext
    {
        public MyDb1()
            : base("name=MyDb1")
        {
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
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MyTable2>()
                .Property(e => e.StudentID)
                .IsFixedLength();

            modelBuilder.Entity<MyTable2>()
                .HasMany(e => e.MyTable3)
                .WithRequired(e => e.MyTable2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MyTable3>()
                .Property(e => e.StudentID)
                .IsFixedLength();

            modelBuilder.Entity<MyTable3>()
                .Property(e => e.KeChengID)
                .IsFixedLength();
        }
    }
}
