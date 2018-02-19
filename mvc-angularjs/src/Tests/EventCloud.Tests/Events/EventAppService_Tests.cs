using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Runtime.Session;
using Abp.Timing;
using Abp.UI;
using EventCloud.EntityFramework;
using EventCloud.Events;
using EventCloud.Events.Dtos;
using EventCloud.Tests.Data;
using EventCloud.Tests.Sessions;
using NSubstitute;
using Shouldly;
using Xunit;

namespace EventCloud.Tests.Events
{
    public class EventAppService_Tests : EventCloudTestBase
    {
        private readonly IEventAppService _eventAppService;

        public EventAppService_Tests()
        {
            _eventAppService = Resolve<IEventAppService>();
        }

        [Fact]
        public async Task Should_Get_Test_Events()
        {
            var output = await _eventAppService.GetList(new GetEventListInput());
            output.Items.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Should_Create_Event()
        {
            //Arrange
            var eventTitle = Guid.NewGuid().ToString();

            //Act
            await _eventAppService.Create(new CreateEventInput
            {
                Title = eventTitle,
                Description = "A description",
                Date = Clock.Now.AddDays(2)
            });

            //Assert
            UsingDbContext(context =>
            {
                context.Events.FirstOrDefault(e => e.Title == eventTitle).ShouldNotBe(null);
            });
        }

        [Fact]
        public async Task Should_Not_Create_Events_In_The_Past()
        {
            //Arrange
            var eventTitle = Guid.NewGuid().ToString();

            //Act
            await Assert.ThrowsAsync<UserFriendlyException>(async () =>
            {
                await _eventAppService.Create(new CreateEventInput
                {
                    Title = eventTitle,
                    Description = "A description",
                    Date = Clock.Now.AddDays(-1)
                });
            });
        }

        [Fact]
        public async Task Should_Cancel_Event()
        {
            //Act
            await _eventAppService.Cancel(new EntityDto<Guid>(GetTestEvent().Id));

            //Assert
            GetTestEvent().IsCancelled.ShouldBeTrue();
        }

        [Fact]
        public async Task Should_Register_To_Events()
        {
            //Arrange
            var testEvent = GetTestEvent();

            //Act
            var output = await _eventAppService.Register(new EntityDto<Guid>(testEvent.Id));

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
            await _eventAppService.CancelRegistration(new EntityDto<Guid>(GetTestEvent().Id));

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
