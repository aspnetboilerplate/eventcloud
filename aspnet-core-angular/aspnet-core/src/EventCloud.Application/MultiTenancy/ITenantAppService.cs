using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EventCloud.MultiTenancy.Dto;

namespace EventCloud.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
