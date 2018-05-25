using Abp.Application.Services;
using System;

namespace EventCloud.Maps
{
    using Abp.Application.Services.Dto;
    using Dtos;

    public interface IMapAppService : IAsyncCrudAppService<MapDto, Guid, PagedResultRequestDto, CreateMapInput, MapDto>
    {

    }
}