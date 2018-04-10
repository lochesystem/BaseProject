using System.Data.Entity.Migrations;

namespace DomainDrivenDesignArchitecture.Repository.EF.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<SimpleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = "EF\\Migrations\\Ver_1_0";
        }

        protected override void Seed(SimpleContext context)
        {
        }
    }
}
