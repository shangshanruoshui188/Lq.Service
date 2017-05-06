using Autofac;
using Autofac.Integration.WebApi;
using Lq.Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Lq.Service.App_Start
{
    public static class AutofacConfig
    {
        public static void ConfigAutofac(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            RegisterTypes(builder);

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }


        private static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.Register(d => new AppDbContext()).As<DbContext>();

        }
    }
}