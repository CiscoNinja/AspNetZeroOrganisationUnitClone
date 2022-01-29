using Abp.Authorization;
using AspNetZeroOrganisationUnitClone.Authorization.Roles;
using AspNetZeroOrganisationUnitClone.Authorization.Users;

namespace AspNetZeroOrganisationUnitClone.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
