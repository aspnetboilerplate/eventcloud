using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace EventCloud.Schedules
{
    using Abp.Domain.Entities.Auditing;
    using Events;

    [Table("AppSchedule")]
    public class Schedule : FullAuditedEntity<Guid>
    {
        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }
        public virtual Guid EventId { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<Group> Groups { get; set; }
    }
}
