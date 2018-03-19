using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventCloud.Schedules
{
    using Abp.Domain.Entities.Auditing;

    [Table("AppTrack")]
    public class Track : FullAuditedEntity<Guid>
    {
        public const int MaxTitleLength = 128;

        public Guid SessionId { get; set; }

        [Required]
        [StringLength(MaxTitleLength)]
        public string Title { get; set; }
    }
}
