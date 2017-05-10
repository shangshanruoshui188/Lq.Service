using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using System;

namespace Lq.Service
{
    public class AuthConfig
    {
        public static OAuthAuthorizationServerOptions ConfigAuth(IOAuthAuthorizationServerProvider provider)
        {
            PublicClientId = "self";
            var options = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),//用户进行认证登陆的地址
                Provider = provider,
                //AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),//外部登陆地址，这个功能已删除
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            };

            return options;
        }


        public static string PublicClientId { get; private set; }

        
    }
}