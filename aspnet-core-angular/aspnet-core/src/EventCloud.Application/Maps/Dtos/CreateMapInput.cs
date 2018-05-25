using System;
using System.ComponentModel.DataAnnotations;

namespace EventCloud.Maps.Dtos
{
    using Abp.AutoMapper;

    [AutoMapTo(typeof(Map))]
    public class CreateMapInput
    {
        public const int MaxTitleLength = 128;

        [Required]
        [StringLength(MaxTitleLength)]
        public virtual string Name { get; set; }

        [Required]
        public virtual Decimal Lat { get; set; }

        [Required]
        public virtual Decimal Lng { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
