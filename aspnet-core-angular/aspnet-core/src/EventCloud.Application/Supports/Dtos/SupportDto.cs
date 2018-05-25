using System;
using System.ComponentModel.DataAnnotations;

namespace EventCloud.Supports.Dtos
{
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;

    [AutoMapFrom(typeof(Support))]
    public class SupportDto : FullAuditedEntityDto<Guid>
    {
        public const int MaxDescriptionLength = 2048;

        [Required]
        public virtual Guid EventId { get; set; }

        [Required]
        [StringLength(MaxDescriptionLength)]
        public virtual string Message { get; set; }

        [Required]
        public virtual bool IsActive { get; set; }
    }
}
