using DomainDrivenDesignArchitecture.IoC;
using Microsoft.Owin.Security.OAuth;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace DomainDrivenDesignArchitecture.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(SimpleInjectorContainer.RegisterServices());

        }
    }
}
