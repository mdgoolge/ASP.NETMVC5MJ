using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc5My.Areas.Chapter03.Models
{
    public class MyStudentModel
    {
        public string XueHao { get; set; }
        public string XingMing { get; set; }
        public string XingBie { get; set; }
        public int NianLing { get; set; }
    }
}