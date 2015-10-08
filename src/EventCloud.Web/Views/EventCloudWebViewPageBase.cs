using Abp.Web.Mvc.Views;

namespace EventCloud.Web.Views
{
    public abstract class EventCloudWebViewPageBase : EventCloudWebViewPageBase<dynamic>
    {

    }

    public abstract class EventCloudWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected EventCloudWebViewPageBase()
        {
            LocalizationSourceName = EventCloudConsts.LocalizationSourceName;
        }
    }
}