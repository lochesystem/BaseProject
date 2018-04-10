using DomainDrivenDesignArchitecture.API.Authorization;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(DomainDrivenDesignArchitecture.API.Startup))]

namespace DomainDrivenDesignArchitecture.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            var config = new HttpConfiguration();

            WebApiConfig.Register(config);

            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/security/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(999),
                Provider = new AuthorizationProvider()
            };

            app.UseCors(CorsOptions.AllowAll);
            //ConfigureAuth(app);

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            app.UseWebApi(config);

        }
    }
}
