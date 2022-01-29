using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AspNetZeroOrganisationUnitClone.Authorization.Roles;
using AspNetZeroOrganisationUnitClone.Authorization.Users;
using AspNetZeroOrganisationUnitClone.MultiTenancy;

namespace AspNetZeroOrganisationUnitClone.EntityFrameworkCore
{
    public class AspNetZeroOrganisationUnitCloneDbContext : AbpZeroDbContext<Tenant, Role, User, AspNetZeroOrganisationUnitCloneDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AspNetZeroOrganisationUnitCloneDbContext(DbContextOptions<AspNetZeroOrganisationUnitCloneDbContext> options)
            : base(options)
        {
        }
    }
}
