using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AspNetZeroOrganisationUnitClone.Configuration;

namespace AspNetZeroOrganisationUnitClone.Web.Host.Startup
{
    [DependsOn(
       typeof(AspNetZeroOrganisationUnitCloneWebCoreModule))]
    public class AspNetZeroOrganisationUnitCloneWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AspNetZeroOrganisationUnitCloneWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AspNetZeroOrganisationUnitCloneWebHostModule).GetAssembly());
        }
    }
}
