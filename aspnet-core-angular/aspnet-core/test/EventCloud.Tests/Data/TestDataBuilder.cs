using System.Linq;
using Abp.Timing;
using EventCloud.EntityFrameworkCore;
using EventCloud.Events;
using EventCloud.MultiTenancy;

namespace EventCloud.Tests.Data
{
    public class TestDataBuilder
    {
        public const string TestEventTitle = "Test event title";

        private readonly EventCloudDbContext _context;

        public TestDataBuilder(EventCloudDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            CreateTestEvent();
        }

        private void CreateTestEvent()
        {
            var defaultTenant = _context.Tenants.Single(t => t.TenancyName == Tenant.DefaultTenantName);
            _context.Events.Add(Event.Create(defaultTenant.Id, TestEventTitle, Clock.Now.AddDays(1)));
            _context.SaveChanges();
        }
    }
}
