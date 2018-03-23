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


        /// <summary>
        /// We don't make constructor public and forcing to create events using <see cref="Create"/> method.
        /// But constructor can not be private since it's used by EntityFramework.
        /// Thats why we did it protected.
        /// </summary>
        protected Track()
        {

        }

        public static Track Create(Guid sessionId, string title)
        {
            var @track = new Track
            {
                SessionId = sessionId,
                Title = title
            };

            return @track;
        }
    }
}
