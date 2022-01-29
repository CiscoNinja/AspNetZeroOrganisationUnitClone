using System.Threading.Tasks;
using AspNetZeroOrganisationUnitClone.Configuration.Dto;

namespace AspNetZeroOrganisationUnitClone.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
