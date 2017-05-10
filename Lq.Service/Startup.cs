using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using Autofac;
using System.Web.Http;
using Autofac.Integration.WebApi;
using Microsoft.Owin.Security.DataProtection;

[assembly: OwinStartup(typeof(Lq.Service.Startup))]

namespace Lq.Service
{
    public partial class Startup
    {

        /// <summary>
        /// 用于在UserManager中加密Token，不得以的Trick，一种比较Ditry的做法，但是没有办法
        /// 这个对象只能从IAppBuilder中获取
        /// </summary>
        public static IDataProtectionProvider DataProtectionProvider { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            var container = ConfigAutofac(app);
            ConfigureAuth(app,container);
            ConfigureWebApi(app,container);
        }


        /// <summary>
        /// 使用Autofac框架进行依赖注入
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        private IContainer ConfigAutofac(IAppBuilder app)
        {
            DataProtectionProvider = app.GetDataProtectionProvider();
            IContainer container= AutofacConfig.ConfigAutofac();
            app.UseAutofacMiddleware(container);
            return container;
        }


        /// <summary>
        /// 配置OAuth，使用Bearer token进行鉴权
        /// </summary>
        /// <param name="app"></param>
        /// <param name="container"></param>
        private void ConfigureAuth(IAppBuilder app,IContainer container)
        {
            /**
             * 依赖注入，注意要提前注册ApplicationOAuthProvider类
             **/
            var provider = container.Resolve<IOAuthAuthorizationServerProvider>();
            var options = AuthConfig.ConfigAuth(provider);
            app.UseOAuthBearerTokens(options);
        }

        /// <summary>
        /// 基于Autofac利用DI将WebApi Middleware注入到Owin
        /// </summary>
        /// <param name="app"></param>
        /// <param name="container"></param>
        private void ConfigureWebApi(IAppBuilder app,IContainer container)
        {
            HttpConfiguration config= WebApiConfig.ConfigWebApi();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
        }
        
    }
}
