using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using EventCloud.Configuration.Dto;

namespace EventCloud.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : EventCloudAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
