using System;

namespace EventCloud.Supports
{
    using Abp.Domain.Repositories;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Dtos;

    [AbpAuthorize]
    public class SupportAppService : AsyncCrudAppService<Support, SupportDto, Guid, PagedResultRequestDto, CreateSupportInput, SupportDto>, ISupportAppService
    {
        private IRepository<Support, Guid> _supportRepository;

        public SupportAppService(
            IRepository<Support, Guid> supportRepository
        )
            : base(supportRepository)
        {
            _supportRepository = supportRepository;
        }
    }
}