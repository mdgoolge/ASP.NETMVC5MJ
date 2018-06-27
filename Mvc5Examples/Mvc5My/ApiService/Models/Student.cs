using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc5My.ApiService.Models
{
    [Table("Student")]
    public class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [StringLength(8, MinimumLength = 8)]
        [Display(Name = "学号"), DisplayFormat(DataFormatString = "{0:d8}")]
        public string ID { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Range(0, 100, ErrorMessage = "成绩必须是0～100之间的整数。")]
        [Display(Name = "成绩")]
        public int? Grade { get; set; }
    }
}