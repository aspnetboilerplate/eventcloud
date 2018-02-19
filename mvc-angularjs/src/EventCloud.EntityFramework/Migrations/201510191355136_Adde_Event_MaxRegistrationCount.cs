namespace EventCloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adde_Event_MaxRegistrationCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppEvents", "MaxRegistrationCount", c => c.Int(nullable: false, defaultValue: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppEvents", "MaxRegistrationCount");
        }
    }
}
