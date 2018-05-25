using System;

namespace EventCloud.Abouts
{
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Dtos;

    public interface IAboutAppService : IAsyncCrudAppService<AboutDto, Guid, PagedResultRequestDto, CreateAboutInput, AboutDto>
    {

    }
}
