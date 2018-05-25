using System;

namespace EventCloud.Maps.Dtos
{
    using Abp.AutoMapper;

    [AutoMapTo(typeof(Map))]
    public class MapListDto
    {
        public virtual string Name { get; set; }

        public virtual Decimal Lat { get; set; }

        public virtual Decimal Lng { get; set; }

        public virtual bool IsActive { get; set; }
    }
}
