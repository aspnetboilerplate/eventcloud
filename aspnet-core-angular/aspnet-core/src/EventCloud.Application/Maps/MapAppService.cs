using System;

namespace EventCloud.Maps
{
    using Abp.Domain.Repositories;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Dtos;

    [AbpAuthorize]
    public class MapAppService : AsyncCrudAppService<Map, MapDto, Guid, PagedResultRequestDto, CreateMapInput, MapDto>, IMapAppService
    {
        private IRepository<Map, Guid> _mapRepository;

        public MapAppService(
            IRepository<Map, Guid> mapRepository
        )
            : base(mapRepository)
        {
            _mapRepository = mapRepository;
        }
    }
}
