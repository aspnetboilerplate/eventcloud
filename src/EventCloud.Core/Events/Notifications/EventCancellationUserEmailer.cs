using System.Data.Entity;
using System.Linq;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Events.Bus.Handlers;
using Castle.Core.Logging;
using EventCloud.Users;

namespace EventCloud.Events.Notifications
{
    public class EventCancellationUserEmailer : IEventHandler<EventCancelledEvent>, ITransientDependency
    {
        public ILogger Logger { get; set; }

        private readonly IRepository<EventRegistration> _eventRegistrationRepository;

        public EventCancellationUserEmailer(IRepository<EventRegistration> eventRegistrationRepository)
        {
            _eventRegistrationRepository = eventRegistrationRepository;

            Logger = NullLogger.Instance;
        }

        public void HandleEvent(EventCancelledEvent eventData)
        {
            var registrations = _eventRegistrationRepository
                .GetAll()
                .Include(e => e.User)
                .Where(e => e.EventId == eventData.Entity.Id)
                .ToList();

            foreach (var registration in registrations)
            {
                SendCancellationEmail(eventData.Entity, registration.User);
            }
        }

        private void SendCancellationEmail(Event @event, User user)
        {
            //TODO: Send the email!

            var message = @event.Title + " event is canceled!";
            Logger.Debug($"TODO: Send email to {user.EmailAddress} -> {message}");
        }
    }
}