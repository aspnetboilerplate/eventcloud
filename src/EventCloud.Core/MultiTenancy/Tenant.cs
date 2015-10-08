using Abp.MultiTenancy;
using EventCloud.Users;

namespace EventCloud.MultiTenancy
{
    public class Tenant : AbpTenant<Tenant, User>
    {

    }
}