using System.Threading.Tasks;

namespace EventCloud.Groups
{
    using Abp.Application.Services;
    using Dto;

    public interface ITrackAppService : IApplicationService
    {
        Task CreateAsync(CreateTrackInput input);
    }
}
