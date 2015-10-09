using System;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Runtime.Session;
using EventCloud.Events.Dtos;
using EventCloud.Users;

namespace EventCloud.Events
{
    [AbpAuthorize]
    public class EventAppService : EventCloudAppServiceBase, IEventAppService
    {
        private readonly IEventManager _eventManager;

        public EventAppService(IEventManager eventManager)
        {
            _eventManager = eventManager;
        }

        public async Task Create(CreateEventInput input)
        {
            var @event = Event.Create(AbpSession.GetTenantId(), input.Title, input.Date, input.Description, input.MinAgeToRegister);
            await _eventManager.CreateAsync(@event);
        }

        public async Task Cancel(EntityRequestInput<Guid> input)
        {
            var @event = await _eventManager.GetAsync(input.Id);
            _eventManager.Cancel(@event);
        }

        public async Task<EventRegisterOutput> Register(EntityRequestInput<Guid> input)
        {
            var registration = await RegisterAndSaveAsync(
                await _eventManager.GetAsync(input.Id),
                await GetCurrentUserAsync()
                );

            return new EventRegisterOutput
            {
                RegistrationId = registration.Id
            };
        }

        public async Task CancelRegistration(EntityRequestInput<Guid> input)
        {
            await _eventManager.CancelRegistrationAsync(
                await _eventManager.GetAsync(input.Id),
                await GetCurrentUserAsync()
                );
        }

        private async Task<EventRegistration> RegisterAndSaveAsync(Event @event, User user)
        {
            var registration = await _eventManager.RegisterAsync(@event, user);
            await CurrentUnitOfWork.SaveChangesAsync();
            return registration;
        }
    }
}