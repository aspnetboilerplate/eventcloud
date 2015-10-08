using Abp.Authorization.Roles;
using EventCloud.MultiTenancy;
using EventCloud.Users;

namespace EventCloud.Authorization.Roles
{
    public class Role : AbpRole<Tenant, User>
    {

    }
}