using System;
using System.Collections.Generic;

namespace EventCloud.Groups.Dto
{
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;

    [AutoMapFrom(typeof(Schedules.Session))]
    public class SessionDto : FullAuditedEntityDto<Guid>
    {
        public Guid GroupId { get; set; }

        public string Name { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public string Location { get; set; }

        public ICollection<TrackDto> Tracks { get; set; }
    }
}
