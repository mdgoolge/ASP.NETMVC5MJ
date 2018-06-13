using System.Web;
using System.Web.Optimization;

namespace Mvc5My
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //基本功能
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            ////jQuery 的非介入式ajax
            bundles.Add(new ScriptBundle("~/bundles/jquery/unobtrusive-ajax").Include("~/Scripts/jquery.unobtrusive*"));

            ////jquery客户端验证
            bundles.Add(new ScriptBundle("~/bundles/jquery/validate").Include(
                        "~/Scripts/jquery.validate*"));

            ////jqueryUI脚本
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                         "~/Scripts/jquery-ui-{version}.js",
                         "~/Scripts/jquery-ui-datepicker-cn.js"
                         ));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //Bootstrap和respond脚本
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //模板默认使用的CSS文件
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //jqueryUI的CSS文件
            bundles.Add(new StyleBundle("~/Content/themes/base/jquery-ui").Include(
                      "~/Content/themes/base/all.css"));

         
            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            BundleTable.EnableOptimizations = true;
   
        }
    }
}
