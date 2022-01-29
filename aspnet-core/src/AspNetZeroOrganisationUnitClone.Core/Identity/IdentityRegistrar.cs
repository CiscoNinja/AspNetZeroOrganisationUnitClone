using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using AspNetZeroOrganisationUnitClone.Authorization;
using AspNetZeroOrganisationUnitClone.Authorization.Roles;
using AspNetZeroOrganisationUnitClone.Authorization.Users;
using AspNetZeroOrganisationUnitClone.Editions;
using AspNetZeroOrganisationUnitClone.MultiTenancy;

namespace AspNetZeroOrganisationUnitClone.Identity
{
    public static class IdentityRegistrar
    {
        public static IdentityBuilder Register(IServiceCollection services)
        {
            services.AddLogging();

            return services.AddAbpIdentity<Tenant, User, Role>()
                .AddAbpTenantManager<TenantManager>()
                .AddAbpUserManager<UserManager>()
                .AddAbpRoleManager<RoleManager>()
                .AddAbpEditionManager<EditionManager>()
                .AddAbpUserStore<UserStore>()
                .AddAbpRoleStore<RoleStore>()
                .AddAbpLogInManager<LogInManager>()
                .AddAbpSignInManager<SignInManager>()
                .AddAbpSecurityStampValidator<SecurityStampValidator>()
                .AddAbpUserClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
                .AddPermissionChecker<PermissionChecker>()
                .AddDefaultTokenProviders();
        }
    }
}
