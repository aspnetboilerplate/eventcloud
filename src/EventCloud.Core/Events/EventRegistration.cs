using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using EventCloud.Users;

namespace EventCloud.Events
{
    [Table("AppEventRegistrations")]
    public class EventRegistration : CreationAuditedEntity
    {
        [ForeignKey("EventId")]
        public virtual Event Event { get; protected set; }
        public virtual Guid EventId { get; protected set; }

        [ForeignKey("UserId")]
        public virtual User User { get; protected set; }
        public virtual long UserId { get; protected set; }

        /// <summary>
        /// We don't make constructor public and forcing to create registrations using <see cref="CreateAsync"/> method.
        /// But constructor can not be private since it's used by EntityFramework.
        /// Thats why we did it protected.
        /// </summary>
        protected EventRegistration()
        {
            
        }

        public async static Task<EventRegistration> CreateAsync(Event @event, User user, IEventRegistrationPolicy registrationPolicy)
        {
            if (@event == null) { throw new ArgumentNullException(nameof(@event)); }
            if (user == null) { throw new ArgumentNullException(nameof(user)); }

            await registrationPolicy.CheckRegistrationAttemptAsync(@event, user);

            return new EventRegistration
            {
                EventId = @event.Id,
                Event = @event,
                UserId = @user.Id,
                User = user
            };
        }
    }
}