using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using System.Data.Entity;
using Mvc5Examples.Areas.Chapter08.Models.MyDb2Model;
using Mvc5Examples.Areas.Chapter08.cs;
using Mvc5Examples.ApiService.Models;

namespace Mvc5Examples
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //（第8章示例）发布时要注释掉该行语句
            Database.SetInitializer<MyDb2>(new MyDb2Init());
            //（第9章示例）发布时要注释掉该行语句
            Database.SetInitializer<MyDb3>(new StudentsInitialize());

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
