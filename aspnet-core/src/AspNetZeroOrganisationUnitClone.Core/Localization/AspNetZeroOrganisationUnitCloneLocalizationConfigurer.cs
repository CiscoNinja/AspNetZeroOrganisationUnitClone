using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AspNetZeroOrganisationUnitClone.Localization
{
    public static class AspNetZeroOrganisationUnitCloneLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AspNetZeroOrganisationUnitCloneConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AspNetZeroOrganisationUnitCloneLocalizationConfigurer).GetAssembly(),
                        "AspNetZeroOrganisationUnitClone.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
