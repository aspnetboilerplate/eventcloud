using Abp;

namespace EventCloud
{
    public class EventCloudServiceBase : AbpServiceBase
    {
        public EventCloudServiceBase()
        {
            LocalizationSourceName = EventCloudConsts.LocalizationSourceName;
        }
    }
}