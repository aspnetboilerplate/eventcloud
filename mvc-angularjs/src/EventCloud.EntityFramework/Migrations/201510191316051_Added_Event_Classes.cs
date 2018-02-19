namespace EventCloud.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Event_Classes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppEventRegistrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenantId = c.Int(nullable: false),
                        EventId = c.Guid(nullable: false),
                        UserId = c.Long(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EventRegistration_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppEvents", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.AbpUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AppEvents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 128),
                        Description = c.String(maxLength: 2048),
                        Date = c.DateTime(nullable: false),
                        MinAgeToRegister = c.Int(nullable: false),
                        IsCancelled = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Event_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Event_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AbpUsers", "BirthYear", c => c.Int(nullable: false, defaultValue: 0));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppEventRegistrations", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AppEventRegistrations", "EventId", "dbo.AppEvents");
            DropIndex("dbo.AppEventRegistrations", new[] { "UserId" });
            DropIndex("dbo.AppEventRegistrations", new[] { "EventId" });
            DropColumn("dbo.AbpUsers", "BirthYear");
            DropTable("dbo.AppEvents",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Event_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Event_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AppEventRegistrations",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EventRegistration_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
