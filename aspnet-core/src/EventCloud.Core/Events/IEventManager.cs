using Abp.Domain.Services;
using EventCloud.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCloud.Events
{
    public interface IEventManager : IDomainService
    {
        Task<Event> GetAsync(Guid id);

        Task CreateAsync(Event @event);

        void Cancel(Event @event);

        Task<EventRegistration> RegisterAsync(Event @event, User user);

        Task CancelRegistrationAsync(Event @event, User user);

        Task<IReadOnlyList<User>> GetRegisteredUsersAsync(Event @event);
    }
}
