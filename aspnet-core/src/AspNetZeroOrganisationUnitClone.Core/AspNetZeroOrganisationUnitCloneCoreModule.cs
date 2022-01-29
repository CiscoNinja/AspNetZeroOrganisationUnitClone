using Abp.Localization;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Security;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using AspNetZeroOrganisationUnitClone.Authorization.Roles;
using AspNetZeroOrganisationUnitClone.Authorization.Users;
using AspNetZeroOrganisationUnitClone.Configuration;
using AspNetZeroOrganisationUnitClone.Localization;
using AspNetZeroOrganisationUnitClone.MultiTenancy;
using AspNetZeroOrganisationUnitClone.Timing;

namespace AspNetZeroOrganisationUnitClone
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class AspNetZeroOrganisationUnitCloneCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            AspNetZeroOrganisationUnitCloneLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = AspNetZeroOrganisationUnitCloneConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
            
            Configuration.Localization.Languages.Add(new LanguageInfo("fa", "فارسی", "famfamfam-flags ir"));
            
            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = AspNetZeroOrganisationUnitCloneConsts.DefaultPassPhrase;
            SimpleStringCipher.DefaultPassPhrase = AspNetZeroOrganisationUnitCloneConsts.DefaultPassPhrase;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AspNetZeroOrganisationUnitCloneCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
