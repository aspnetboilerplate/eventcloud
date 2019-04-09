using System;
using Abp.Web;
using Castle.Facilities.Logging;
using Abp.Castle.Logging.Log4Net;

namespace EventCloud.Web
{
    public class MvcApplication : AbpWebApplication<EventCloudWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            AbpBootstrapper.IocManager.IocContainer
                .AddFacility<LoggingFacility>(f => f.UseAbpLog4Net()
                    .WithConfig(Server.MapPath("log4net.config"))
                );

            base.Application_Start(sender, e);
        }
    }
}
