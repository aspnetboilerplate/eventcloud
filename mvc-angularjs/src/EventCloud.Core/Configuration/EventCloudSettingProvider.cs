using System.Collections.Generic;
using Abp.Configuration;

namespace EventCloud.Configuration
{
    public class EventCloudSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
            {
                new SettingDefinition(
                    EventCloudSettingNames.MaxAllowedEventRegistrationCountInLast30DaysPerUser,
                    defaultValue: "10",
                    scopes: SettingScopes.Tenant),
            };
        }
    }
}
