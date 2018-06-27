using Mvc5My.Areas.Chapter08.Models.MyDb2Model;
using System.Data.Entity;

namespace Mvc5Examples.Areas.Chapter08.cs
{
    //定义默认的初始化策略
    //（当模型改变时，如果数据库不存在就自动创建，如果存在就先删除再创建）
    public class MyDb2Init : DropCreateDatabaseIfModelChanges<MyDb2>
    {
        //设置数据库种子（所有表均初始化为无数据）
        protected override void Seed(MyDb2 context)
        {
            base.Seed(context);
        }
    }
}