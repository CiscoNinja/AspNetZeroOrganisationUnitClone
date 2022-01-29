using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AspNetZeroOrganisationUnitClone.Configuration;
using AspNetZeroOrganisationUnitClone.EntityFrameworkCore;
using AspNetZeroOrganisationUnitClone.Migrator.DependencyInjection;

namespace AspNetZeroOrganisationUnitClone.Migrator
{
    [DependsOn(typeof(AspNetZeroOrganisationUnitCloneEntityFrameworkModule))]
    public class AspNetZeroOrganisationUnitCloneMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public AspNetZeroOrganisationUnitCloneMigratorModule(AspNetZeroOrganisationUnitCloneEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(AspNetZeroOrganisationUnitCloneMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                AspNetZeroOrganisationUnitCloneConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AspNetZeroOrganisationUnitCloneMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
