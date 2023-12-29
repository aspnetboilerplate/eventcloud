using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EventCloud.Events.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCloud.Events
{
    public interface IEventAppService : IApplicationService
    {
        Task<ListResultDto<EventListDto>> GetListAsync(GetEventListInput input);

        Task<EventDetailOutput> GetDetailAsync(EntityDto<Guid> input);

        Task CreateAsync(CreateEventInput input);

        Task CancelAsync(EntityDto<Guid> input);

        Task<EventRegisterOutput> RegisterAsync(EntityDto<Guid> input);

        Task CancelRegistrationAsync(EntityDto<Guid> input);
    }
}
