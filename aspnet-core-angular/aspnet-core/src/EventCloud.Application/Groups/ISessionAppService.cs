using System.Threading.Tasks;

namespace EventCloud.Groups
{
    using Abp.Application.Services;
    using EventCloud.Groups.Dto;

    public interface ISessionAppService : IApplicationService
    {
        Task CreateAsync(CreateSessionInput input);
    }
}
