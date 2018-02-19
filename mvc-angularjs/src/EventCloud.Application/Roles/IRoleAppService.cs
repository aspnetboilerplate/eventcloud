using System.Threading.Tasks;
using Abp.Application.Services;
using EventCloud.Roles.Dto;

namespace EventCloud.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
