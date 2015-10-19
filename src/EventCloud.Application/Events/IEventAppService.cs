using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using EventCloud.Events.Dtos;

namespace EventCloud.Events
{
    public interface IEventAppService : IApplicationService
    {
        Task<ListResultOutput<EventListDto>> GetList(GetEventListInput input);

        Task Create(CreateEventInput input);

        Task Cancel(EntityRequestInput<Guid> input);

        Task<EventRegisterOutput> Register(EntityRequestInput<Guid> input);

        Task CancelRegistration(EntityRequestInput<Guid> input);
    }
}
