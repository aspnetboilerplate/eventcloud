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
    using Abp.UI;
    using Dto;

    [AbpAuthorize]
    public class ScheduleAppService : EventCloudAppServiceBase, IScheduleAppService
    {
        private readonly IScheduleManager _scheduleManager;
        private readonly IRepository<Schedule, Guid> _scheduleRepository;

        public ScheduleAppService(
            IScheduleManager scheduleManager,
            IRepository<Schedule, Guid> scheduleRepository)
        {
            _scheduleManager = scheduleManager;
            _scheduleRepository = scheduleRepository;
        }

        public async Task CreateAsync(CreateScheduleInput input)
        {
            var @schedule = Schedule.Create(input.EventId, input.Date);
            await _scheduleManager.CreateAsync(@schedule);
        }

        public async Task<ScheduleDetailOutput> GetDetailAsync(EntityDto<Guid> input)
        {
            var @schedule = await _scheduleRepository
                .GetAll()
                .Include(e => e.Groups)
                .ThenInclude(r => r.Sessions)
                .Where(e => e.Id == input.Id)
                .FirstOrDefaultAsync();

            if (@schedule == null)
            {
                throw new UserFriendlyException("Não foi possível encontrar a programação, talvez ele tenha sido excluída.");
            }

            return @schedule.MapTo<ScheduleDetailOutput>();
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
