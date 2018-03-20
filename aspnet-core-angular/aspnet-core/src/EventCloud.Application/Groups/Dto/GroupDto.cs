using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventCloud.Groups.Dto
{
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;

    [AutoMapFrom(typeof(Schedules.Group))]
    public class GroupDto : FullAuditedEntityDto<Guid>
    {
        public Guid ScheduleId { get; set; }

        [Required]
        [StringLength(Schedules.Group.MaxTimeLength)]
        public string Time { get; set; }

        public IEnumerable<SessionDto> Sessions { get; set; }
    }
}
