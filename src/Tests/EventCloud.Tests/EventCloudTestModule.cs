using Abp.Modules;
using Abp.TestBase;

namespace EventCloud.Tests
{
    [DependsOn(
         typeof(EventCloudApplicationModule),
         typeof(EventCloudDataModule),
         typeof(AbpTestBaseModule)
     )]
    public class EventCloudTestModule : AbpModule
    {

    }
}