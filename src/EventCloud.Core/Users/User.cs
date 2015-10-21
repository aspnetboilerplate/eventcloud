using System;
using Abp.Authorization.Users;
using Abp.Extensions;
using EventCloud.MultiTenancy;
using Microsoft.AspNet.Identity;

namespace EventCloud.Users
{
    public class User : AbpUser<Tenant, User>
    {
        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress, string password)
        {
            return new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Password = new PasswordHasher().HashPassword(password),
                IsEmailConfirmed = true,
                IsActive = true
            };
        }
    }
}