using DomainDrivenDesignArchitecture.API.AutoMapper;
using DomainDrivenDesignArchitecture.Repository.EF.Migrations;
using System.Data.Entity.Migrations;
using System.Web;
using System.Web.Http;

namespace DomainDrivenDesignArchitecture.API
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.RegisterMappings();

            var dbMigrator = new DbMigrator(
               new Configuration());
            dbMigrator.Update();
        }
    }
}
