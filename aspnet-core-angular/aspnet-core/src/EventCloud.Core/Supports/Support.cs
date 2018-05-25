using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventCloud.Supports
{
    using Abp.Domain.Entities.Auditing;
    using Events;

    [Table("AppSupports")]
    public class Support : FullAuditedEntity<Guid>
    {
        public const int MaxDescriptionLength = 2048;

        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }
        public virtual Guid EventId { get; set; }

        [Required]
        [StringLength(MaxDescriptionLength)]
        public virtual string Message { get; set; }

        [Required]
        public virtual bool IsActive { get; set; }

        public Support()
        {

        }
    }
}
