using System.Reflection;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Timing;
using Abp.Zero;
using EventCloud.Configuration;

namespace EventCloud
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class EventCloudCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Remove the following line to disable multi-tenancy.
            Configuration.MultiTenancy.IsEnabled = true;

            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    EventCloudConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(),
                        "EventCloud.Localization.Source"
                        )
                    )
                );

            Configuration.Settings.Providers.Add<EventCloudSettingProvider>();

            Clock.Provider = new UtcClockProvider();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
