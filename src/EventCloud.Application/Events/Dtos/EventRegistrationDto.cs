using System;
using Abp.Application.Services.Dto;

namespace EventCloud.Events.Dtos
{
    public class EventRegistrationDto : CreationAuditedEntityDto
    {
        public virtual Guid EventId { get; protected set; }

        public virtual long UserId { get; protected set; }

        public virtual long UserName { get; protected set; }

        public virtual long UserSurname { get; protected set; }
    }
}