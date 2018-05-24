using Abp.Application.Services;
using System;

namespace EventCloud.Speakers
{
    using Abp.Application.Services.Dto;
    using Dtos;

    public interface ISpeakerAppService : IAsyncCrudAppService<SpeakerDto, Guid, PagedResultRequestDto, CreateSpeakerInput, SpeakerDto>
    {

    }
}
