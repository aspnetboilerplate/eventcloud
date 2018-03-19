using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventCloud.Schedules
{
    using Abp.Domain.Entities.Auditing;

    [Table("AppGroup")]
    public class Group : FullAuditedEntity<Guid>
    {
        public const int MaxTimeLength = 16;

        public Guid ScheduleId { get; set; }

        [Required]
        [StringLength(MaxTimeLength)]
        public string Time { get; set; }

        public IEnumerable<Session> Sessions { get; set; }
    }
}
