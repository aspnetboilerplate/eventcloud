using System;
using System.ComponentModel.DataAnnotations;

namespace EventCloud.Supports.Dtos
{
    using Abp.AutoMapper;

    [AutoMapTo(typeof(Support))]
    public class CreateSupportInput
    {
        public const int MaxDescriptionLength = 2048;

        [Required]
        [StringLength(MaxDescriptionLength)]
        public virtual string Message { get; set; }

        [Required]
        public virtual bool IsActive { get; set; }
    }
}
