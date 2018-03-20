using System;
using System.Collections.Generic;

namespace EventCloud.Schedules.Dto
{
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using Groups.Dto;

    [AutoMapFrom(typeof(Schedule))]
    public class ScheduleDetailOutput : FullAuditedEntityDto<Guid>
    {
        public DateTime Date { get; set; }

        public ICollection<GroupDto> Groups { get; set; }
    }
}