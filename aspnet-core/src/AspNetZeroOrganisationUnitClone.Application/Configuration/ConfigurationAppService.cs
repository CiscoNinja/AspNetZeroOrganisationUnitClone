using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AspNetZeroOrganisationUnitClone.Configuration.Dto;

namespace AspNetZeroOrganisationUnitClone.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AspNetZeroOrganisationUnitCloneAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
