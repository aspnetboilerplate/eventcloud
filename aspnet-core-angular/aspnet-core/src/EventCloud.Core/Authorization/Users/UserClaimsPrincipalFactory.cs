using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using EventCloud.Authorization.Roles;

namespace EventCloud.Authorization.Users
{
    public class UserClaimsPrincipalFactory : AbpUserClaimsPrincipalFactory<User, Role>
    {
        public UserClaimsPrincipalFactory(
            UserManager userManager,
            RoleManager roleManager,
            IOptions<IdentityOptions> optionsAccessor,
            Abp.Domain.Uow.IUnitOfWorkManager unitOfWorkManager )
            : base(
                  userManager,
                  roleManager,
                  optionsAccessor, unitOfWorkManager)
        {
        }
    }
}
