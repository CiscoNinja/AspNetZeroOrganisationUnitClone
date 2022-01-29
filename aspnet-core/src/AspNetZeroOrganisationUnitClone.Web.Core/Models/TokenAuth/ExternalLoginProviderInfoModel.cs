using Abp.AutoMapper;
using AspNetZeroOrganisationUnitClone.Authentication.External;

namespace AspNetZeroOrganisationUnitClone.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
