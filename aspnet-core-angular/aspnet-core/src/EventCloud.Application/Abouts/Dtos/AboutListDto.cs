using System;

namespace EventCloud.Abouts.Dtos
{
    using Abp.Application.Services.Dto;

    public class AboutListDto : FullAuditedEntityDto<Guid>
    {
        public virtual string Key { get; set; }

        public virtual string Value { get; set; }

        public virtual bool IsActive { get; set; }
    }
}
