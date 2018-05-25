using System;
using System.ComponentModel.DataAnnotations;

namespace EventCloud.Maps.Dtos
{
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;

    [AutoMapFrom(typeof(Map))]
    public class MapDto : FullAuditedEntityDto<Guid>
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
        public virtual bool IsActive { get; set; }    
    }
}
