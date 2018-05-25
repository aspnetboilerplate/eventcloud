using System;
using System.ComponentModel.DataAnnotations;

namespace EventCloud.Abouts.Dtos
{
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;

    [AutoMapFrom(typeof(About))]
    public class AboutDto : FullAuditedEntityDto<Guid>
    {
        public const int MaxKeyLength = 128;

        [Required]
        public virtual Guid EventId { get; set; }

        [StringLength(MaxKeyLength)]
        [Required]
        public virtual string Key { get; set; }

        [Required]
        public virtual string Value { get; set; }

        [Required]
        public virtual bool IsActive { get; set; }
    }
}
