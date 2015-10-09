using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace EventCloud.Events
{
    [Table("AppEvents")]
    public class Event : FullAuditedEntity<Guid>
    {
        public const int MaxTitleLength = 128;
        public const int MaxDescriptionLength = 128;

        [Required]
        [StringLength(MaxTitleLength)]
        public virtual string Title { get; protected set; }

        [StringLength(MaxDescriptionLength)]
        public virtual string Description { get; protected set; }

        public virtual DateTime Date { get; protected set; }

        [Range(0, 128)]
        public virtual int MinAgeToRegister { get; protected set; }

        /// <summary>
        /// We don't make constructor public and forcing to create events using <see cref="Create"/> method.
        /// But constructor can not be private since it's used by EntityFramework.
        /// Thats why we did it protected.
        /// </summary>
        protected Event()
        {

        }

        public static Event Create(string title, DateTime date, string description = null, int minAgeToRegister = 0)
        {
            return new Event
            {
                Id = Guid.NewGuid(),
                Title = title,
                Date = date,
                Description = description,
                MinAgeToRegister = minAgeToRegister,
            };
        }

        public bool IsInPast()
        {
            return Date < Clock.Now;
        }

        public bool IsAllowedCancellationTimeEnded()
        {
            return Date.Subtract(Clock.Now).TotalHours <= 2.0; //2 hours can be defined as Event property and determined per event
        }
    }
}
