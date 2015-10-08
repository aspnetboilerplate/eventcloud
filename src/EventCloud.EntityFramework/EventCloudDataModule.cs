using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using EventCloud.EntityFramework;

namespace EventCloud
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(EventCloudCoreModule))]
    public class EventCloudDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
