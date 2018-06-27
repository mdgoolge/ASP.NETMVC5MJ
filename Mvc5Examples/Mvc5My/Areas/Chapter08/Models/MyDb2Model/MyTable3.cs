using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc5My.Areas.Chapter08.Models.MyDb2Model
{
    [Table("MyTable3")]
    public class MyTable3
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(8)]
        [Display(Name = "学号")]
        public string StudentID { get; set; }

        [StringLength(3)]
        [Display(Name = "课程编号")]
        public string KeChengID { get; set; }

        [Range(0, 100, ErrorMessage = "成绩必须是0～100之间的整数。")]
        [Display(Name = "成绩")]
        public int? Grade { get; set; }

        public virtual MyTable1 MyTable1 { get; set; }
        public virtual MyTable2 MyTable2 { get; set; }
    }
}