using System.Threading.Tasks;
using Abp.Domain.Repositories;
using EventCloud.Users;

namespace EventCloud.Events
{
    public class EventManager : IEventManager
    {
        private readonly IEventRegistrationPolicy _registrationPolicy;
        private readonly IRepository<EventRegistration> _eventRegistrationRepository;

        public EventManager(
            IEventRegistrationPolicy registrationPolicy,
            IRepository<EventRegistration> eventRegistrationRepository)
        {
            _registrationPolicy = registrationPolicy;
            _eventRegistrationRepository = eventRegistrationRepository;
        }

        public async Task<EventRegistration> RegisterAsync(Event @event, User user)
        {
            return await _eventRegistrationRepository.InsertAsync(
                await EventRegistration.CreateAsync(@event, user, _registrationPolicy)
                );
        }

        public async Task CancelRegistrationAsync(Event @event, User user)
        {
            var registration = await _eventRegistrationRepository.FirstOrDefaultAsync(r => r.EventId == @event.Id && r.UserId == user.Id);
            if (registration == null)
            {
                //No need to cancel since there is no such a registration
                return;
            }

            await registration.CancelAsync(_eventRegistrationRepository);
        }
    }
}