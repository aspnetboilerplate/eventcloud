using Abp.Authorization;
using EventCloud.Authorization.Roles;
using EventCloud.Authorization.Users;

namespace EventCloud.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
