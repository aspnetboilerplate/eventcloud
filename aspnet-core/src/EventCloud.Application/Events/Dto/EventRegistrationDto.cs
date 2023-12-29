using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace EventCloud.Events.Dto
{
    [AutoMapFrom(typeof(EventRegistration))]
    public class EventRegistrationDto : CreationAuditedEntityDto
    {
        public virtual Guid EventId { get; protected set; }

        public virtual long UserId { get; protected set; }

        public virtual string UserName { get; protected set; }

        public virtual string UserSurname { get; protected set; }
    }
}
