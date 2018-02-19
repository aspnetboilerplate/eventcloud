using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace EventCloud
{
    [DependsOn(typeof(EventCloudCoreModule), typeof(AbpAutoMapperModule))]
    public class EventCloudApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
