using System;
using System.ComponentModel.DataAnnotations;

namespace EventCloud.Groups.Dto
{
    public class CreateGroupInput
    {
        public Guid ScheduleId { get; set; }

        [Required]
        [StringLength(Schedules.Group.MaxTimeLength)]
        public string Time { get; set; }
    }
}
