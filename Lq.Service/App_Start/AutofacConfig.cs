using Autofac;
using Autofac.Integration.WebApi;
using Lq.Service.Models;
using Lq.Service.Models.Identity;
using Lq.Service.Providers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using System.Data.Entity;
using System.Reflection;

namespace Lq.Service
{
    public static class AutofacConfig
    {
        public static IContainer ConfigAutofac()
        {
            var builder = new ContainerBuilder();

            RegisterTypes(builder);

            var container = builder.Build();
            
            return container;
        }


        private static void RegisterTypes(ContainerBuilder builder)
        {
           
            //注册使用到的Service
            builder.Register(d => new AppDbContext()).As<DbContext>();

            builder.RegisterType<UserStore>().As<IUserStore<User, int>>();

            //使用属性注入的方式赋值UserManager的DataProtectorTokenProvider属性
            builder.RegisterType<UserManager>().OnActivating(a=>
            a.Instance.SetUserTokenProvider(Startup.DataProtectionProvider));

            builder.RegisterType<ApplicationOAuthProvider>().As<IOAuthAuthorizationServerProvider>();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());//注册所有的控制器，DI接管控制器的创建
        }
    }
}