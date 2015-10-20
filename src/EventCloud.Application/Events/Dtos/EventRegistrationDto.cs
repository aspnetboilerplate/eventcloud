using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace EventCloud.Events.Dtos
{
    [AutoMapFrom(typeof(EventRegistration))]
    public class EventRegistrationDto : CreationAuditedEntityDto
    {
        public virtual Guid EventId { get; protected set; }

        public virtual long UserId { get; protected set; }

        public virtual long UserName { get; protected set; }

        public virtual long UserSurname { get; protected set; }
    }
}