using System.Threading.Tasks;
using Abp.Application.Services;
using EventCloud.Authorization.Accounts.Dto;

namespace EventCloud.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
