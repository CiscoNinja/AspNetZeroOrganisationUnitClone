using AspNetZeroOrganisationUnitClone.Debugging;

namespace AspNetZeroOrganisationUnitClone
{
    public class AspNetZeroOrganisationUnitCloneConsts
    {
        public const string LocalizationSourceName = "AspNetZeroOrganisationUnitClone";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "42a44869339d48f2bad54ba3fd58a03f";
    }
}
