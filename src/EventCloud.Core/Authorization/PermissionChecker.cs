using Abp.Authorization;
using EventCloud.Authorization.Roles;
using EventCloud.MultiTenancy;
using EventCloud.Users;

namespace EventCloud.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
