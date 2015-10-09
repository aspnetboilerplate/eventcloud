using System;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using EventCloud.Events.Dtos;
using EventCloud.Users;

namespace EventCloud.Events
{
    [AbpAuthorize]
    public class EventRegistrationAppService : EventCloudAppServiceBase, IEventRegistrationAppService
    {
        private readonly IRepository<Event, Guid> _eventRepository;
        private readonly IEventManager _eventManager;

        public EventRegistrationAppService(
            IRepository<Event, Guid> eventRepository,
            IEventManager eventManager
            )
        {
            _eventRepository = eventRepository;
            _eventManager = eventManager;
        }

        public async Task<EventRegisterOutput> Register(EntityRequestInput<Guid> input)
        {
            var registration = await RegisterAndSaveAsync(
                await GetEventAsync(input.Id),
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
                await GetEventAsync(input.Id),
                await GetCurrentUserAsync()
                );
        }

        private async Task<Event> GetEventAsync(Guid id)
        {
            var @event = await _eventRepository.FirstOrDefaultAsync(id);
            if (@event == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted!");
            }

            return @event;
        }

        private async Task<EventRegistration> RegisterAndSaveAsync(Event @event, User user)
        {
            var registration = await _eventManager.RegisterAsync(@event, user);
            await CurrentUnitOfWork.SaveChangesAsync();
            return registration;
        }
    }
}