using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventCloud.Maps
{
    using Abp.Domain.Entities.Auditing;
    using Events;

    [Table("AppMaps")]
    public class Map : FullAuditedEntity<Guid>
    {
        public const int MaxTitleLength = 128;

        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }
        public virtual Guid EventId { get; set; }

        [Required]
        [StringLength(MaxTitleLength)]
        public virtual string Name { get; set; }

        [Required]
        public virtual Decimal Lat { get; set; }

        [Required]
        public virtual Decimal Lng { get; set; }

        [Required]
        public virtual bool IsActive { get; set; }

        public Map()
        {

        }
    }
}
