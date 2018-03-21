
namespace EventCloud.Schedules
{
    using Abp.Events.Bus.Entities;

    public class ScheduleDateChangedSchedule : EntityEventData<Schedule>
    {
        public ScheduleDateChangedSchedule(Schedule entity)
            : base(entity)
        {

        }
    }
}
