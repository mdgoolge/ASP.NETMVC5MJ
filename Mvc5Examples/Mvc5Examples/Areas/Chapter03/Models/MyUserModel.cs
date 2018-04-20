using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc5Examples.Areas.Chapter03.Models
{
    public class MyUserModel
    {
        [Display(Name = "用户Id")]
        [Required]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "用户Id必须为3个字符")]
        public string UserId { get; set; }

        [Display(Name = "用户名")]
        [Required(ErrorMessage = "用户名不能为空")]
        [StringLength(50, MinimumLength = 2)]
        public string UserName { get; set; }

        [Display(Name = "密码")]
        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(20, MinimumLength = 6)]
        public string UserPassword { get; set; }

        [Display(Name = "年龄")]
        [Required]
        [Range(18, 60, ErrorMessage = "年龄必须是18到60之间的整数")]
        public int Age { get; set; }

        [Display(Name = "预存金额")]
        [Required]
        [Range(10, int.MaxValue, ErrorMessage = "预存金额不能低于10元")]
        public double Money { get; set; }

        [Display(Name = "出生日期")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "其他信息")]
        public string OtherInfo { get; set; }

        public MyUserModel()
        {
            UserId = "001";
            UserPassword = "123456";
            UserName = "张三易";
            Age = 20;
            Money = 15.6;
            BirthDate = DateTime.Now.Date;
        }
    }
}