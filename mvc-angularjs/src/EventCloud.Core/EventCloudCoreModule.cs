using System.Reflection;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.MultiTenancy;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using EventCloud.Authorization.Roles;
using EventCloud.Configuration;

namespace EventCloud
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class EventCloudCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.MultiTenancy.IsEnabled = true;

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

            Configuration.Modules.Zero().RoleManagement.StaticRoles.Add(new StaticRoleDefinition(StaticRoleNames.Tenant.Admin, MultiTenancySides.Host));
            Configuration.Modules.Zero().RoleManagement.StaticRoles.Add(new StaticRoleDefinition(StaticRoleNames.Tenant.Admin, MultiTenancySides.Tenant));
            Configuration.Modules.Zero().RoleManagement.StaticRoles.Add(new StaticRoleDefinition(StaticRoleNames.Tenant.Member, MultiTenancySides.Tenant));

            Clock.Provider = ClockProviders.Utc;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
