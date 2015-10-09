using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Runtime.Session;
using EventCloud.EntityFramework;
using EventCloud.Events;
using EventCloud.Tests.Data;
using EventCloud.Tests.Sessions;
using NSubstitute;
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
            var testEvent = GetTestEvent();

            //Act
            var output = await _eventRegistrationAppService.Register(new EntityRequestInput<Guid>(testEvent.Id));

            //Assert
            output.RegistrationId.ShouldBeGreaterThan(0);

            UsingDbContext(context =>
            {
                var currentUserId = AbpSession.GetUserId();
                var registration = context.EventRegistrations.FirstOrDefault(r => r.EventId == testEvent.Id && r.UserId == currentUserId);
                registration.ShouldNotBeNull();
            });
        }

        [Fact]
        public async Task Should_Cancel_Registration()
        {
            //Arrange
            var currentUserId = AbpSession.GetUserId();
            await UsingDbContext(async context =>
            {
                var testEvent = GetTestEvent(context);
                var currentUser = await context.Users.SingleAsync(u => u.Id == currentUserId);
                var testRegistration = await EventRegistration.CreateAsync(
                    testEvent,
                    currentUser,
                    Substitute.For<IEventRegistrationPolicy>()
                    );

                context.EventRegistrations.Add(testRegistration);
            });

            //Act
            await _eventRegistrationAppService.CancelRegistration(new EntityRequestInput<Guid>(GetTestEvent().Id));

            //Assert
            UsingDbContext(context =>
            {
                var testEvent = GetTestEvent(context);
                var testRegistration = context.EventRegistrations.FirstOrDefault(r => r.EventId == testEvent.Id && r.UserId == currentUserId);
                testRegistration.ShouldBeNull();
            });
        }

        private Event GetTestEvent()
        {
            return UsingDbContext(context => GetTestEvent(context));
        }

        private static Event GetTestEvent(EventCloudDbContext context)
        {
            return context.Events.Single(e => e.Title == TestDataBuilder.TestEventTitle);
        }
    }
}
