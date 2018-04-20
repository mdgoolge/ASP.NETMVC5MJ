using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

//Demo2
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using Mvc5Examples.ApiService.Models;

namespace Mvc5Examples
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Student>("Students");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
