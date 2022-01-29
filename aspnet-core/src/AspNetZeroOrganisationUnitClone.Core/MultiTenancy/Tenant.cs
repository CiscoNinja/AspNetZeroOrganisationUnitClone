using Abp.MultiTenancy;
using AspNetZeroOrganisationUnitClone.Authorization.Users;

namespace AspNetZeroOrganisationUnitClone.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
