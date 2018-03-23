using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace EventCloud.Schedules
{
    using Abp.Domain.Entities.Auditing;
    using Abp.Timing;
    using Abp.UI;
    using EventCloud.Domain.Events;
    using Events;

    [Table("AppSchedule")]
    public class Schedule : FullAuditedEntity<Guid>
    {
        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }
        public virtual Guid EventId { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        /// <summary>
        /// We don't make constructor public and forcing to create events using <see cref="Create"/> method.
        /// But constructor can not be private since it's used by EntityFramework.
        /// Thats why we did it protected.
        /// </summary>
        protected Schedule()
        {

        }

        public static Schedule Create(Guid eventId, DateTime date)
        {
            var @schedule = new Schedule
            {
                EventId = eventId,
                Date = date
            };

            @schedule.SetDate(date);

            return @schedule;
        }

        private void SetDate(DateTime date)
        {
            if (date < Clock.Now)
            {
                throw new UserFriendlyException("Não é possível definir a data de um evento no passado!");
            }

            if (date <= Clock.Now.AddHours(3)) //3 can be configurable per tenant
            {
                throw new UserFriendlyException("Deve definir a data de um evento pelo menos 3 horas antes!");
            }

            Date = date;

            DomainEvents.EventBus.Trigger(new ScheduleDateChangedSchedule(this));
        }
    }
}
