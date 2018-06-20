using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc5My.Areas.Chapter05.Models
{
    public class MyClass2Model
    {
        [Display(Name = "性别")]
        [Required]
        public string Gender { get; set; }

        /// <summary>体育活动</summary>
        public Dictionary<string, bool> MySports { get; set; }

        /// <summary>业余活动</summary>
        public List<string> MyExtDoings { get; set; }

        /// <summary>最喜欢的业余活动</summary>
        public List<string> MyFavExtDoings { get; set; }

        /// <summary>业余活动可选列表</summary>
        public List<string> ExtDoingList { get; set; }

        //设置默认选项
        public MyClass2Model()
        {
            Gender = "女";
            MySports = new Dictionary<string, bool>
            {
                {"足球", true},
                {"篮球", false},
                {"排球", false},
                {"乒乓球", true},
                {"羽毛球", false},
            };
            MyExtDoings = new List<string>
            {
                {"足球"}, {"排球"}, {"跳绳"}
            };
            MyFavExtDoings = new List<string>{ "跳绳" };
            ExtDoingList = Enum.GetNames(typeof(DoingEnums)).ToList();
        }
    }
    public enum DoingEnums {
        足球, 篮球, 排球, 乒乓球, 羽毛球, 跳绳, 跑步, 钓鱼, 打猎, 游泳, 跳舞,
        打牌, 下象棋, 下围棋, 下跳棋, 玩游戏, 逛商场, 网购, 看电影, 看电视,
        玩手机, 其他
    }
}