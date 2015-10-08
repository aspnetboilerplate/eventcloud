using Abp;

namespace EventCloud.Events
{
    public class EventCloudServiceBase : AbpServiceBase
    {
        public EventCloudServiceBase()
        {
            LocalizationSourceName = EventCloudConsts.LocalizationSourceName;
        }
    }
}