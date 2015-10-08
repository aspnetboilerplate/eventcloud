using System;
using Abp.Authorization.Users;
using Abp.Extensions;
using EventCloud.MultiTenancy;

namespace EventCloud.Users
{
    public class User : AbpUser<Tenant, User>
    {
        public virtual int BirthYear { get; set; }

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }
    }
}