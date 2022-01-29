using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AspNetZeroOrganisationUnitClone.Authorization;

namespace AspNetZeroOrganisationUnitClone
{
    [DependsOn(
        typeof(AspNetZeroOrganisationUnitCloneCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AspNetZeroOrganisationUnitCloneApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AspNetZeroOrganisationUnitCloneAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AspNetZeroOrganisationUnitCloneApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
