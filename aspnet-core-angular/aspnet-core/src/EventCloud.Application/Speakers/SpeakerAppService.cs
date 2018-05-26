using System;

namespace EventCloud.Speakers
{
    using Abp.Domain.Repositories;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Dtos;
    using Authorization;

    public class SpeakerAppService : AsyncCrudAppService<Speaker, SpeakerDto, Guid, PagedResultRequestDto, CreateSpeakerInput, SpeakerDto>, ISpeakerAppService
    {
        private IRepository<Speaker, Guid> _speakerRepository;

        public SpeakerAppService(
            IRepository<Speaker, Guid> speakerRepository    
        )
            : base (speakerRepository)
        {
            _speakerRepository = speakerRepository;
        }
    }
}
