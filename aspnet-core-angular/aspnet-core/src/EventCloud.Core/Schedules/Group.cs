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

        public virtual ICollection<Session> Sessions { get; set; }

        /// <summary>
        /// We don't make constructor public and forcing to create events using <see cref="Create"/> method.
        /// But constructor can not be private since it's used by EntityFramework.
        /// Thats why we did it protected.
        /// </summary>
        protected Group()
        {

        }

        public static Group Create(Guid scheduleId, string time)
        {
            var @group = new Group
            {
                ScheduleId = scheduleId,
                Time = time
            };

            return @group;
        }
    }
}
