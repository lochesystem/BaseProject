using System.Web.Http;
using WebActivatorEx;
using DomainDrivenDesignArchitecture.API;
using Swashbuckle.Application;
using DomainDrivenDesignArchitecture.API.Filters;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace DomainDrivenDesignArchitecture.API
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.DocumentFilter<TokenEndpointDocumentFilter>();

                        c.SingleApiVersion("v1", "DomainDrivenDesignArchitecture.API");
                        c.IncludeXmlComments(string.Format(@"{0}\bin\DomainDrivenDesignArchitecture.API.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                        c.OperationFilter<AddAuthorizationHeaderParameterOperationFilter>();
                    })
                    .EnableSwaggerUi(config => config.DocExpansion(DocExpansion.List));

        }
    }
}
