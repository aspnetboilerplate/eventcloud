using System;

namespace EventCloud.Supports.Dtos
{
    using Abp.Application.Services.Dto;

    public class SupportListDto : FullAuditedEntityDto<Guid>
    {
        public virtual Guid EventId { get; set; }

        public virtual string Message { get; set; }

        public virtual bool IsActive { get; set; }
    }
}
