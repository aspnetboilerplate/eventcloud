﻿using System;
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
        private readonly IRepository<Group, Guid> _groupRepository;
        private readonly IRepository<Session, Guid> _sessionRepository;

        public ScheduleAppService(
            IScheduleManager scheduleManager,
            IRepository<Schedule, Guid> scheduleRepository,
            IRepository<Group, Guid> groupRepository,
            IRepository<Session, Guid> sessionRepository)
        {
            _scheduleManager = scheduleManager;
            _scheduleRepository = scheduleRepository;
            _groupRepository = groupRepository;
            _sessionRepository = sessionRepository;
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

        public ListResultDto<ScheduleListDto> GetListAsync()
        {
            try
            {
                var schedules = _scheduleRepository
                    .GetAllIncluding(prop => prop.Groups)
                    .ToList();

                schedules.ForEach(prop => prop.Groups = _groupRepository
                                                            .GetAllIncluding(g => g.Sessions)
                                                            .Where(g => g.ScheduleId == prop.Id)
                                                            .ToList());

                schedules.ForEach(prop => prop.Groups.ToList()
                                                     .ForEach(g => g.Sessions = _sessionRepository
                                                                                      .GetAllIncluding(s => s.Tracks)
                                                                                      .Where(s => s.GroupId == g.Id)
                                                                                      .ToList()));

                return new ListResultDto<ScheduleListDto>(schedules.MapTo<List<ScheduleListDto>>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}