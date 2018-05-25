using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventCloud.Supports
{
    using Abp.Domain.Entities.Auditing;

    [Table("AppSupports")]
    public class Support : FullAuditedEntity<Guid>
    {
        public const int MaxDescriptionLength = 2048;

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
