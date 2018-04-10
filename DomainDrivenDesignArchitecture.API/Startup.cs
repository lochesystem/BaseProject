using DomainDrivenDesignArchitecture.API.Authorization;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

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

    public class TokenEndpointDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.paths.Add("/security/token", new PathItem
            {
                post = new Operation
                {
                    tags = new string[] { "Authentication" },
                    summary = "Authenticates provided credentials and returns an access token",
                    operationId = "OAuth2TokenPost",
                    consumes = new string[] { "application/x-www-form-url-encoded" },
                    produces = new string[] { "application/json" },
                    parameters = new List<Parameter>
                {
                    new Parameter
                    {
                        name = "username",
                        @in = "formData",
                        type = "string"
                    },
                    new Parameter
                    {
                        name = "password",
                        @in = "formData",
                        type = "string",
                        format = "password"
                    },
                    new Parameter
                    {
                        name = "grant_type",
                        @in = "formData",
                        type = "string",
                    }
                },
                    responses = new Dictionary<string, Response>
                {
                    {
                        "200",
                        new Response
                        {
                            description = "Success",
                            schema = new Schema
                            {
                                type = "object",
                                properties = new Dictionary<string, Schema>
                                {
                                    {
                                        "access_token",
                                        new Schema
                                        {
                                            type = "string"
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                }
            });
        }
    }
}
