using System;

namespace EventCloud.Schedules.Dto
{
    public class CreateScheduleInput
    {
        public Guid EventId { get; set; }
        public DateTime Date { get; set; }
    }
}
