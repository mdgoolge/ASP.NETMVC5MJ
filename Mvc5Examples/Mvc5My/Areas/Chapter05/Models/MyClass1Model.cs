using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc5My.Areas.Chapter05.Models
{
    public class MyClass1Model
    {
        [Required]
        public int n1 { get; set; }

        [Required]
        public int n2 { get; set; }
    }
}