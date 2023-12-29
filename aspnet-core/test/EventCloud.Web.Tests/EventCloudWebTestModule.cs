using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EventCloud.EntityFrameworkCore;
using EventCloud.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace EventCloud.Web.Tests
{
    [DependsOn(
        typeof(EventCloudWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class EventCloudWebTestModule : AbpModule
    {
        public EventCloudWebTestModule(EventCloudEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EventCloudWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(EventCloudWebMvcModule).Assembly);
        }
    }
}