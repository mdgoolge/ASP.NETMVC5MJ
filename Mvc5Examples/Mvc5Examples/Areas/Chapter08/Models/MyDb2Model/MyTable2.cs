using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace Mvc5Examples.Areas.Chapter08.Models.MyDb2Model
{
    [Table("MyTable2")]
    public class MyTable2
    {
        public MyTable2()
        {
            MyTable3 = new HashSet<MyTable3>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [StringLength(8, MinimumLength = 8)]
        [Display(Name = "学号"), DisplayFormat(DataFormatString = "{0:d8}")]
        public string StudentID { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "姓名")]
        public string StudentName { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "入学时间"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? RuXueShiJian { get; set; }

        public virtual ICollection<MyTable3> MyTable3 { get; set; }
    }
}
