using Abp.Events.Bus.Entities;

namespace EventCloud.Events
{
    public class EventCancelledEvent : EntityEventData<Event>
    {
        public EventCancelledEvent(Event entity)
            : base(entity)
        {
        }
    }
}
