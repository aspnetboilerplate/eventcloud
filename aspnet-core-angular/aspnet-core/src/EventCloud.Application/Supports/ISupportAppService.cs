using System;

namespace EventCloud.Supports
{
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Dtos;

    public interface ISupportAppService : IAsyncCrudAppService<SupportDto, Guid, PagedResultRequestDto, CreateSupportInput, SupportDto>
    {

    }
}