using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AspNetZeroOrganisationUnitClone.EntityFrameworkCore;
using AspNetZeroOrganisationUnitClone.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace AspNetZeroOrganisationUnitClone.Web.Tests
{
    [DependsOn(
        typeof(AspNetZeroOrganisationUnitCloneWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class AspNetZeroOrganisationUnitCloneWebTestModule : AbpModule
    {
        public AspNetZeroOrganisationUnitCloneWebTestModule(AspNetZeroOrganisationUnitCloneEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AspNetZeroOrganisationUnitCloneWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(AspNetZeroOrganisationUnitCloneWebMvcModule).Assembly);
        }
    }
}