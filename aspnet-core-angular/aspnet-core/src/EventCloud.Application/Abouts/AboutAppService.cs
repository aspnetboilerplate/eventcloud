using System;

namespace EventCloud.Abouts
{
    using Abp.Domain.Repositories;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Dtos;

    [AbpAuthorize]
    public class AboutAppService : AsyncCrudAppService<About, AboutDto, Guid, PagedResultRequestDto, CreateAboutInput, AboutDto>, IAboutAppService
    {
        private IRepository<About, Guid> _aboutRepository;

        public AboutAppService(
            IRepository<About, Guid> aboutRepository
        )
            : base(aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }
    }
}
