namespace Mvc5Examples.Areas.Chapter08.Models.MyDb1Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MyTable2
    {
        public MyTable2()
        {
            MyTable3 = new HashSet<MyTable3>();
        }

        [Key]
        [StringLength(8)]
        public string StudentID { get; set; }

        [Required]
        [StringLength(30)]
        public string StudentName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RuXueShiJian { get; set; }

        public virtual ICollection<MyTable3> MyTable3 { get; set; }
    }
}
