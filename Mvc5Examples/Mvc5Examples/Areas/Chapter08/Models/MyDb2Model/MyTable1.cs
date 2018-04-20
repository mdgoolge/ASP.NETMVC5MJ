using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace Mvc5Examples.Areas.Chapter08.Models.MyDb2Model
{
    [Table("MyTable1")]
    public class MyTable1
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [StringLength(3, MinimumLength = 3)]
        [Display(Name = "¿Î³Ì±àºÅ")]
        public string KeChengID { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "¿Î³ÌÃû³Æ")]
        public string KeChengName { get; set; }

        public virtual ICollection<MyTable3> MyTable3 { get; set; }
    }
}
