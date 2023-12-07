﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using EventCloud.Authorization.Roles;
using EventCloud.Authorization.Users;
using EventCloud.MultiTenancy;

namespace EventCloud.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options, 
            SignInManager signInManager,
            ISystemClock systemClock,
            Microsoft.Extensions.Logging.ILoggerFactory loggerFactory,
            Abp.Domain.Uow.IUnitOfWorkManager unitOfWorkManager) 
            : base(
                  options, 
                  signInManager, 
                  systemClock,loggerFactory,unitOfWorkManager)
        {
        }
    }
}
