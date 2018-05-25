using System.ComponentModel.DataAnnotations;

namespace EventCloud.Abouts.Dtos
{
    using Abp.AutoMapper;

    [AutoMapTo(typeof(About))]
    public class CreateAboutInput 
    {
        public const int MaxKeyLength = 128;

        [Required]
        [StringLength(MaxKeyLength)]
        public virtual string Key { get; set; }

        [Required]
        public virtual string Value { get; set; }

        [Required]
        public virtual bool IsActive { get; set; }
    }
}
