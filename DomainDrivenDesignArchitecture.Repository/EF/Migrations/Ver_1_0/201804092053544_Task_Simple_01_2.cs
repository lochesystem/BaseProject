namespace DomainDrivenDesignArchitecture.Repository.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Task_Simple_01_2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User", "FirstAccess");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "FirstAccess", c => c.Boolean(nullable: false));
        }
    }
}
