using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc5My.Areas.Chapter08.Models.MyDb2Model
{
    [Table("MyTable1")]
    public class MyTable1
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [StringLength(3, MinimumLength = 3)]
        [Display(Name = "课程编号")]
        public string KeChengID { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "课程名称")]
        public string KeChengName { get; set; }

        public virtual ICollection<MyTable3> MyTable3 { get; set; }
    }
}