using Abp.Events.Bus;

namespace EventCloud.Domain.Events
{
    public static class DomainEvents
    {
        public static IEventBus EventBus { get; set; }

        static DomainEvents()
        {
            EventBus = Abp.Events.Bus.EventBus.Default;
        }
    }
}
