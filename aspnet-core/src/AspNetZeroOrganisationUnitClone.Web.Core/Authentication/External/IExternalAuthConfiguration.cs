using System.Collections.Generic;

namespace AspNetZeroOrganisationUnitClone.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
