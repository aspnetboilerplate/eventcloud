using System.Data.Entity.Migrations;
using EventCloud.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace EventCloud.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EventCloud.EntityFramework.EventCloudDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EventCloud";
        }

        protected override void Seed(EventCloud.EntityFramework.EventCloudDbContext context)
        {
            context.DisableAllFilters();
            new InitialDataBuilder(context).Build();
        }
    }
}
