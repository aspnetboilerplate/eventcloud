using System.Threading.Tasks;

namespace EventCloud.Groups
{
    using Abp.Application.Services;
    using Dto;

    public interface IGroupAppService : IApplicationService
    {
        Task CreateAsync(CreateGroupInput input);    
    }
}
