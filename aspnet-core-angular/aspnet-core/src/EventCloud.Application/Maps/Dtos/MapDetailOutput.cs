using System;

namespace EventCloud.Maps.Dtos
{
    using Abp.Application.Services.Dto;

    public class MapDetailOutput : FullAuditedEntityDto<Guid>
    {
        public virtual string Name { get; set; }

        public virtual Decimal Lat { get; set; }

        public virtual Decimal Lng { get; set; }

        public virtual bool IsActive { get; set; }
    }
}
