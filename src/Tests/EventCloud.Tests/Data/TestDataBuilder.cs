using Abp.Timing;
using EventCloud.EntityFramework;
using EventCloud.Events;

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
            _context.Events.Add(Event.Create(TestEventTitle, Clock.Now.AddDays(1)));
        }
    }
}