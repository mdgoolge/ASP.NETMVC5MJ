namespace Mvc5My.Models.MyDb1Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MyTable3
    {
        [Required]
        [StringLength(8)]
        public string StudentID { get; set; }

        [Required]
        [StringLength(3)]
        public string KeChengID { get; set; }

        public int Grade { get; set; }

        public int ID { get; set; }

        public virtual MyTable1 MyTable1 { get; set; }

        public virtual MyTable2 MyTable2 { get; set; }
    }
}
