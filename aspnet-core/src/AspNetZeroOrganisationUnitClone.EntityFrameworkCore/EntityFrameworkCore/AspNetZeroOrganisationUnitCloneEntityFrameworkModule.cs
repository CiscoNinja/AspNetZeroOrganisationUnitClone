using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using AspNetZeroOrganisationUnitClone.EntityFrameworkCore.Seed;

namespace AspNetZeroOrganisationUnitClone.EntityFrameworkCore
{
    [DependsOn(
        typeof(AspNetZeroOrganisationUnitCloneCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class AspNetZeroOrganisationUnitCloneEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<AspNetZeroOrganisationUnitCloneDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        AspNetZeroOrganisationUnitCloneDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        AspNetZeroOrganisationUnitCloneDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AspNetZeroOrganisationUnitCloneEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
