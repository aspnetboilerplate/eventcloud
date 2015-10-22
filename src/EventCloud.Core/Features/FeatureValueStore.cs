using Abp.Application.Features;
using EventCloud.Authorization.Roles;
using EventCloud.MultiTenancy;
using EventCloud.Users;

namespace EventCloud.Features
{
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, Role, User>
    {
        public FeatureValueStore(TenantManager tenantManager)
            : base(tenantManager)
        {
        }
    }
}
