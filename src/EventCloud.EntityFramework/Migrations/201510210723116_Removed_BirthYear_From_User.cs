namespace EventCloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removed_BirthYear_From_User : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AbpUsers", "BirthYear");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AbpUsers", "BirthYear", c => c.Int(nullable: false));
        }
    }
}
