using System.Linq;
using Abp.Authorization.Users;
using EventCloud.Authorization.Roles;
using EventCloud.EntityFramework;
using EventCloud.MultiTenancy;
using EventCloud.Users;

namespace EventCloud.Migrations.SeedData
{
    public class DefaultTenantRoleAndUserBuilder
    {
        private readonly EventCloudDbContext _context;

        public DefaultTenantRoleAndUserBuilder(EventCloudDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Admin role for host

            var adminRoleForTenancyOwner = _context.Roles.FirstOrDefault(r => r.TenantId == null && r.Name == StaticRoleNames.Host.Admin);
            if (adminRoleForTenancyOwner == null)
            {
                adminRoleForTenancyOwner = _context.Roles.Add(new Role { Name = StaticRoleNames.Host.Admin, DisplayName = StaticRoleNames.Host.Admin, IsStatic = true });
                _context.SaveChanges();
            }

            //Admin user for tenancy owner

            var adminUserForTenancyOwner = _context.Users.FirstOrDefault(u => u.TenantId == null && u.UserName == "admin");
            if (adminUserForTenancyOwner == null)
            {
                adminUserForTenancyOwner = _context.Users.Add(
                    new User
                    {
                        TenantId = null,
                        UserName = "admin",
                        Name = "System",
                        Surname = "Administrator",
                        EmailAddress = "admin@aspnetboilerplate.com",
                        IsEmailConfirmed = true,
                        Password = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==", //123qwe
                    });

                adminUserForTenancyOwner.SetNormalizedNames();

                _context.SaveChanges();

                _context.UserRoles.Add(new UserRole(null, adminUserForTenancyOwner.Id, adminRoleForTenancyOwner.Id));

                _context.SaveChanges();
            }

            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                defaultTenant = _context.Tenants.Add(new Tenant { TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName });
                _context.SaveChanges();
            }

            //Admin role for 'Default' tenant

            var adminRoleForDefaultTenant = _context.Roles.FirstOrDefault(r => r.TenantId == defaultTenant.Id && r.Name == StaticRoleNames.Tenant.Admin);
            if (adminRoleForDefaultTenant == null)
            {
                adminRoleForDefaultTenant = _context.Roles.Add(new Role { TenantId = defaultTenant.Id, Name = StaticRoleNames.Tenant.Admin, DisplayName = StaticRoleNames.Tenant.Admin, IsStatic = true });
                _context.SaveChanges();
            }

            //Member role for 'Default' tenant
            var memberRoleForDefaultTenant = _context.Roles.FirstOrDefault(r => r.TenantId == defaultTenant.Id && r.Name == StaticRoleNames.Tenant.Member);
            if (memberRoleForDefaultTenant == null)
            {
                _context.Roles.Add(new Role { TenantId = defaultTenant.Id, Name = StaticRoleNames.Tenant.Member, DisplayName = StaticRoleNames.Tenant.Member, IsStatic = true });
                _context.SaveChanges();
            }

            //Admin user for 'Default' tenant

            var adminUserForDefaultTenant = _context.Users.FirstOrDefault(u => u.TenantId == defaultTenant.Id && u.UserName == "admin");
            if (adminUserForDefaultTenant == null)
            {
                adminUserForDefaultTenant = _context.Users.Add(
                    new User
                    {
                        TenantId = defaultTenant.Id,
                        UserName = "admin",
                        Name = "System",
                        Surname = "Administrator",
                        EmailAddress = "admin@aspnetboilerplate.com",
                        IsEmailConfirmed = true,
                        Password = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==", //123qwe
                    });
                adminUserForDefaultTenant.SetNormalizedNames();
                _context.SaveChanges();

                _context.UserRoles.Add(new UserRole(defaultTenant.Id, adminUserForDefaultTenant.Id, adminRoleForDefaultTenant.Id));
                _context.SaveChanges();
            }
        }
    }
}