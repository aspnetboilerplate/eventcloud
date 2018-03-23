using System;
using System.ComponentModel.DataAnnotations;

namespace EventCloud.Groups.Dto
{
    public class CreateTrackInput
    {
        public Guid SessionId { get; set; }

        [Required]
        [StringLength(Schedules.Track.MaxTitleLength)]
        public string Title { get; set; }
    }
}
