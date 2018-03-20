using System;
using System.Collections.Generic;

namespace EventCloud.Schedules.Dto
{
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using Groups.Dto;

    [AutoMapFrom(typeof(Schedule))]
    public class ScheduleListDto : FullAuditedEntityDto<Guid>
    {
        public DateTime Date { get; set; }

        public IEnumerable<GroupDto> Groups { get; set; }

        public bool IsCancelled { get; set; }

        public virtual int MaxRegistrationCount { get; protected set; }

        public int RegistrationsCount { get; set; }
    }
}
