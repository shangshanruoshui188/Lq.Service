using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Dispatcher;
using Lq.Service.Models.Query;
using Lq.Service.Extensions;

namespace Lq.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //泛型控制器选择器
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerSelector), new ControllerSelector(GlobalConfiguration.Configuration));

            //所有数据返回json
            config.Formatters.Remove(config.Formatters.XmlFormatter);


            //QueryModel绑定器
            config.ParameterBindingRules.Insert(0, p =>
            {
                if (p.ParameterType == typeof(QueryModel))
                    return new QueryModelParameterBinding(p);
                return null;
            });

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //默认路由配置一定要保留controller这个选项，因为所有的Controller都是由GenericController<T>这个
            //泛型控制器生成的，而在反射时，需要得到T的类型消息，而这个类型消息便是通过{controller}获取到的。
            //尽管在路由中配置action并不符合Restful风格，但为了能够通过get方式进行自定义查询，因此需配置acction。
            config.Routes.MapHttpRoute(
                name: "GenericApi",
                routeTemplate: "genapi/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
