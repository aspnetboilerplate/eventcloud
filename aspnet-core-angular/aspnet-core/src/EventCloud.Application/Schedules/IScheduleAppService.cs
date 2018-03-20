using System;
using System.Threading.Tasks;

namespace EventCloud.Schedules
{
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using EventCloud.Schedules.Dto;

    public interface IScheduleAppService : IApplicationService
    {
        Task<ListResultDto<ScheduleListDto>> GetListAsync();

        Task<ScheduleDetailOutput> GetDetailAsync(EntityDto<Guid> input);

        Task CreateAsync(CreateScheduleInput input);
    }
}
