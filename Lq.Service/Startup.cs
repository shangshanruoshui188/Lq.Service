using System;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using Lq.Service.Models;
using Lq.Service.Providers;

[assembly: OwinStartup(typeof(Lq.Service.Startup))]

namespace Lq.Service
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureWebApi(app);
        }

        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        private void ConfigureAuth(IAppBuilder app)
        {
            
            app.CreatePerOwinContext(AppDbContext.Create);
            app.CreatePerOwinContext<UserManager>(UserManager.Create);

            
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            };

            app.UseOAuthBearerTokens(OAuthOptions);

            
        }

        private void ConfigureWebApi(IAppBuilder app)
        {
            app.UseWebApi(WebApiConfig.ConfigWebApi());
        }
        
    }
}
