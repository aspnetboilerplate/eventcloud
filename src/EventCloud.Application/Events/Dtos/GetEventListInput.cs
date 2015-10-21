using Abp.Application.Services.Dto;

namespace EventCloud.Events.Dtos
{
    public class GetEventListInput : IInputDto
    {
        public bool IncludeCanceledEvents { get; set; }
    }
}