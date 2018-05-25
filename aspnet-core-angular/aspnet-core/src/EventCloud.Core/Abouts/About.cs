using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventCloud.Abouts
{
    using Abp.Domain.Entities.Auditing;

    [Table("AppAbouts")]
    public class About : FullAuditedEntity<Guid>
    {
        public const int MaxKeyLength = 128;

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
