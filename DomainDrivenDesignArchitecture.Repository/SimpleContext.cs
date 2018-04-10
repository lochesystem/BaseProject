namespace DomainDrivenDesignArchitecture.Repository
{
    using DomainDrivenDesignArchitecture.Repository.EF.Config;
    using DomainDrivenDesignArchitecture.Repository.EF.Migrations;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class SimpleContext : DbContext
    {

        public SimpleContext()
            : base("name=SimpleContext")
        {
            Initilize();
        }

        private void Initilize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SimpleContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            #region A

            #endregion

            #region E

            #endregion  

            #region S

            #endregion

            #region P

            #endregion

            #region L

            #endregion

            #region M

            #endregion  

            #region U

            modelBuilder.Configurations.Add(new UserConfig());

            #endregion

            base.OnModelCreating(modelBuilder);
        }

    }
}