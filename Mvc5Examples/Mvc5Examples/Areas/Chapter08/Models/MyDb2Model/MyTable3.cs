using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace Mvc5Examples.Areas.Chapter08.Models.MyDb2Model
{
    [Table("MyTable3")]
    public class MyTable3
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(8)]
        [Display(Name = "ѧ��")]
        public string StudentID { get; set; }

        [StringLength(3)]
        [Display(Name = "�γ̱��")]
        public string KeChengID { get; set; }

        [Range(0, 100, ErrorMessage = "�ɼ�������0��100֮���������")]
        [Display(Name = "�ɼ�")]
        public int? Grade { get; set; }

        public virtual MyTable1 MyTable1 { get; set; }
        public virtual MyTable2 MyTable2 { get; set; }
    }
}
