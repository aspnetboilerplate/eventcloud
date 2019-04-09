using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.Modules;
using Abp.Web;
using Abp.Web.Mvc;
using Abp.Web.Mvc.Configuration;
using EventCloud.Api;
using EventCloud.Web.Navigation;

namespace EventCloud.Web
{
    [DependsOn(
        typeof(EventCloudDataModule), 
        typeof(EventCloudApplicationModule), 
        typeof(EventCloudWebApiModule),
        typeof(AbpWebModule),
        typeof(AbpWebMvcModule)
        )]
    public class EventCloudWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpMvc().IsAutomaticAntiForgeryValidationEnabled = false;
            Configuration.Modules.AbpWebApi().IsAutomaticAntiForgeryValidationEnabled = false;

            //Add/remove languages for your application
            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-england", true));
            Configuration.Localization.Languages.Add(new LanguageInfo("tr", "Türkçe", "famfamfam-flag-tr"));

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<EventCloudNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
