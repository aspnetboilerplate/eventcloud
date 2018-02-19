using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EventCloud.Events.Dtos;

namespace EventCloud.Events
{
    public interface IEventAppService : IApplicationService
    {
        Task<ListResultDto<EventListDto>> GetList(GetEventListInput input);

        Task<EventDetailOutput> GetDetail(EntityDto<Guid> input);

        Task Create(CreateEventInput input);

        Task Cancel(EntityDto<Guid> input);

        Task<EventRegisterOutput> Register(EntityDto<Guid> input);

        Task CancelRegistration(EntityDto<Guid> input);
    }
}
