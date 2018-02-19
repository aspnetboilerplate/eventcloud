using System.Threading.Tasks;
using Abp.Application.Services;
using EventCloud.Users.Dto;

namespace EventCloud.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);
    }
}