using System.ComponentModel.DataAnnotations;

namespace EventCloud.Speakers.Dtos
{
    using Abp.AutoMapper;
    using System;

    [AutoMapTo(typeof(Speaker))]
    public class CreateSpeakerInput
    {
        public const int MaxTitleLength = 128;
        public const int MaxDescriptionLength = 2048;

        [Required]
        public virtual Guid EventId { get; set; }

        public virtual string profilePic { get; set; }

        [Required]
        [StringLength(MaxTitleLength)]
        public virtual string Name { get; set; }

        [Required]
        [StringLength(MaxTitleLength)]
        public virtual string Title { get; set; }

        [Required]
        [StringLength(MaxDescriptionLength)]
        public virtual string About { get; set; }

        [StringLength(MaxDescriptionLength)]
        public virtual string Twitter { get; set; }

        [StringLength(MaxDescriptionLength)]
        public virtual string GitHub { get; set; }

        [StringLength(MaxDescriptionLength)]
        public virtual string Instagram { get; set; }

        [Required]
        public virtual bool IsActive { get; set; }
    }
}
