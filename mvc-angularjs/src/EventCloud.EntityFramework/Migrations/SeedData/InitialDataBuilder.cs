using EventCloud.EntityFramework;

namespace EventCloud.Migrations.SeedData
{
    public class InitialDataBuilder
    {
        private readonly EventCloudDbContext _context;

        public InitialDataBuilder(EventCloudDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            new DefaultTenantRoleAndUserBuilder(_context).Build();
        }
    }
}
