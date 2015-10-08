using System.Linq;
using System.Threading.Tasks;
using Abp.Runtime.Session;
using EventCloud.Events;
using EventCloud.Events.Dtos;
using EventCloud.Tests.Data;
using EventCloud.Tests.Sessions;
using Shouldly;
using Xunit;

namespace EventCloud.Tests.Events
{
    public class EventRegistrationAppService_Tests : EventCloudTestBase
    {
        private readonly IEventRegistrationAppService _eventRegistrationAppService;

        public EventRegistrationAppService_Tests()
        {
            _eventRegistrationAppService = Resolve<IEventRegistrationAppService>();
        }

        [Fact]
        public async Task Should_Register_To_Events()
        {
            //Arrange
            var testEvent = UsingDbContext(context => context.Events.Single(e => e.Title == TestDataBuilder.TestEventTitle));

            //Act
            var output = await _eventRegistrationAppService.Register(new EventRegisterInput { EventId = testEvent.Id });

            //Assert
            output.RegistrationId.ShouldBeGreaterThan(0);

            UsingDbContext(context =>
            {
                var currentUserId = AbpSession.GetUserId();
                var registration = context.EventRegistrations.FirstOrDefault(r => r.EventId == testEvent.Id && r.UserId == currentUserId);
                registration.ShouldNotBeNull();
            });
        }
    }
}
