using Abp.Application.Services;
using EventCloud.MultiTenancy.Dto;

namespace EventCloud.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

