using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AspNetZeroOrganisationUnitClone.Controllers
{
    public abstract class AspNetZeroOrganisationUnitCloneControllerBase: AbpController
    {
        protected AspNetZeroOrganisationUnitCloneControllerBase()
        {
            LocalizationSourceName = AspNetZeroOrganisationUnitCloneConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
