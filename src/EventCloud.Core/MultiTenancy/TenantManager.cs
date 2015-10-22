using Abp.MultiTenancy;
using EventCloud.Authorization.Roles;
using EventCloud.Editions;
using EventCloud.Users;

namespace EventCloud.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, Role, User>
    {
        public TenantManager(EditionManager editionManager)
            : base(editionManager)
        {

        }
    }
}