using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using EventCloud.Authorization.Roles;
using EventCloud.Editions;
using EventCloud.Users;

namespace EventCloud.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, Role, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager
            ) : base(
            tenantRepository, 
            tenantFeatureRepository, 
            editionManager)
        {
        }
    }
}