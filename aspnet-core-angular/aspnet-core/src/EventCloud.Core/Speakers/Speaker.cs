using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventCloud.Speakers
{
    using Abp.Domain.Entities.Auditing;

    [Table("AppSpeakers")]
    public class Speaker : FullAuditedEntity<Guid>
    {
        public const int MaxTitleLength = 128;
        public const int MaxDescriptionLength = 2048;

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

        public Speaker()
        {

        }
    }
}
