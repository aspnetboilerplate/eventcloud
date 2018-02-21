using System.Threading.Tasks;
using EventCloud.MultiTenancy.Dto;

namespace EventCloud.MultiTenancy
{
    public interface ITenantRegistrationAppService
    {
        Task<TenantDto> RegisterTenantAsync(CreateTenantDto input);
    }
}