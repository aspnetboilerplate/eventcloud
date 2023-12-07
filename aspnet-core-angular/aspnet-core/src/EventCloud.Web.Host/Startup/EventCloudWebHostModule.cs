using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EventCloud.Configuration;

namespace EventCloud.Web.Host.Startup
{
    [DependsOn(
       typeof(EventCloudWebCoreModule))]
    public class EventCloudWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public EventCloudWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EventCloudWebHostModule).GetAssembly());
        }
    }
}
