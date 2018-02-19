using System.Threading.Tasks;
using Abp.Application.Services;
using EventCloud.Sessions.Dto;

namespace EventCloud.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
