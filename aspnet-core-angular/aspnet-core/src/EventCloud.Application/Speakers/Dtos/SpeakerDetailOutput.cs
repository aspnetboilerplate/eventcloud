using System;

namespace EventCloud.Speakers.Dtos
{
    using Abp.Application.Services.Dto;

    public class SpeakerDetailOutput : FullAuditedEntityDto<Guid>
    {
        public virtual Guid EventId { get; set; }

        public virtual string profilePic { get; set; }

        public virtual string Name { get; set; }

        public virtual string Title { get; set; }

        public virtual string About { get; set; }

        public virtual string Twitter { get; set; }

        public virtual string GitHub { get; set; }

        public virtual string Instagram { get; set; }

        public virtual bool IsActive { get; set; }
    }
}
