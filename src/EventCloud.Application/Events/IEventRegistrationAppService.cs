using System.Threading.Tasks;
using Abp.Application.Services;
using EventCloud.Events.Dtos;

namespace EventCloud.Events
{
    public interface IEventRegistrationAppService : IApplicationService
    {
        Task<EventRegisterOutput> Register(EventRegisterInput input);
    }
}
