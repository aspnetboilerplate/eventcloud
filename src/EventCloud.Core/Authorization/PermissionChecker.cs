using Abp.Authorization;
using EventCloud.Authorization.Roles;
using EventCloud.Users;

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
