using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace EventCloud.Schedules
{
    using Abp.Domain.Entities.Auditing;

    [Table("AppSession")]
    public class Session : FullAuditedEntity<Guid>
    {
        public Guid GroupId { get; set; }

        public string Name { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public string Location { get; set; }

        public IEnumerable<Track> Tracks { get; set; }
    }
}
