using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EventCloud.Schedules
{
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Domain.Repositories;
    using Events;
    using Schedules.Dto;

    [AbpAuthorize]
    public class ScheduleAppService : EventCloudAppServiceBase, IScheduleAppService
    {
        private readonly IEventManager _scheduleManager;
        private readonly IRepository<Schedule, Guid> _scheduleRepository;

        public ScheduleAppService(
            IEventManager scheduleManager,
            IRepository<Schedule, Guid> scheduleRepository)
        {
            _scheduleManager = scheduleManager;
            _scheduleRepository = scheduleRepository;
        }

        public Task CreateAsync(CreateScheduleInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ScheduleDetailOutput> GetDetailAsync(EntityDto<Guid> input)
        {
            throw new NotImplementedException();
        }

        public async Task<ListResultDto<ScheduleListDto>> GetListAsync()
        {
            var schedules = await _scheduleRepository
                .GetAll()
                .Include(e => e.Groups)
                .OrderByDescending(e => e.Date)
                .Take(64)
                .ToListAsync();

            return new ListResultDto<ScheduleListDto>(schedules.MapTo<List<ScheduleListDto>>());
        }
    }
}
