using System;
using System.Threading.Tasks;
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

        public async Task<EventRegisterOutput> Register(EventRegisterInput input)
        {
            var @event = await _eventRepository.FirstOrDefaultAsync(input.EventId);
            if (@event == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted!");
            }

            return await RegisterEventForUserInternal(@event, await GetCurrentUserAsync());
        }

        private async Task<EventRegisterOutput> RegisterEventForUserInternal(Event @event, User user)
        {
            var registration = await _eventManager.RegisterAsync(@event, user);
            await CurrentUnitOfWork.SaveChangesAsync();
            return new EventRegisterOutput { RegistrationId = registration.Id };
        }
    }
}