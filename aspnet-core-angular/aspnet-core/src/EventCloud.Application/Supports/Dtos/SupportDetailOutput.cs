using System;

namespace EventCloud.Supports.Dtos
{
    using Abp.Application.Services.Dto;

    public class SupportDetailOutput : FullAuditedEntityDto<Guid>
    {
        public virtual string Message { get; set; }

        public virtual bool IsActive { get; set; }
    }
}
