using System;

namespace EventCloud.Abouts.Dtos
{
    using Abp.Application.Services.Dto;

    public class AboutDetailOutput : FullAuditedEntityDto<Guid>
    {
        public const int MaxKeyLength = 128;

        public virtual string Key { get; set; }

        public virtual string Value { get; set; }

        public virtual bool IsActive { get; set; }
    }
}
