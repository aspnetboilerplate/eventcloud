namespace EventCloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Upgraded_To_Abp_V_2_1_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AbpLanguages", "IsDisabled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AbpLanguages", "IsDisabled");
        }
    }
}
