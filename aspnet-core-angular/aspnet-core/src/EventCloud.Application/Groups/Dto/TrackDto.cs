using System;
using System.ComponentModel.DataAnnotations;

namespace EventCloud.Groups.Dto
{
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;

    [AutoMapFrom(typeof(Schedules.Track))]
    public class TrackDto : FullAuditedEntityDto<Guid>
    {
        public Guid SessionId { get; set; }

        [Required]
        [StringLength(Schedules.Track.MaxTitleLength)]
        public string Title { get; set; }
    }
}
