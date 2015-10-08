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
    }
}