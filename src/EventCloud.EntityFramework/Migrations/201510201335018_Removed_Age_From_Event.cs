namespace EventCloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removed_Age_From_Event : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AppEvents", "MinAgeToRegister");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppEvents", "MinAgeToRegister", c => c.Int(nullable: false));
        }
    }
}
