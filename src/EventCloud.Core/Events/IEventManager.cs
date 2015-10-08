using System.Threading.Tasks;
using Abp.Domain.Services;
using EventCloud.Users;

namespace EventCloud.Events
{
    public interface IEventManager : IDomainService
    {
        Task<EventRegistration> RegisterAsync(Event @event, User user);
    }
}