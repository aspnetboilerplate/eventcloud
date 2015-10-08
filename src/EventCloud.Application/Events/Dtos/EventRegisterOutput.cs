using Abp.Application.Services.Dto;

namespace EventCloud.Events.Dtos
{
    public class EventRegisterOutput : IOutputDto
    {
        public int RegistrationId { get; set; }
    }
}