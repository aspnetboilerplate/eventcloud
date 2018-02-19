using System.Threading.Tasks;
using EventCloud.Configuration.Dto;

namespace EventCloud.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
