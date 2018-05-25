using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventCloud.Abouts
{
    using Abp.Domain.Entities.Auditing;
    using Events;

    [Table("AppAbouts")]
    public class About : FullAuditedEntity<Guid>
    {
        public const int MaxKeyLength = 128;

        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }
        public virtual Guid EventId { get; set; }

        [StringLength(MaxKeyLength)]
        [Required]
        public virtual string Key { get; set; }

        [Required]
        public virtual string Value { get; set; }

        [Required]
        public virtual bool IsActive { get; set; }

        public About()
        {

        }
    }
}
