using System.ComponentModel.DataAnnotations;

namespace AspNetZeroOrganisationUnitClone.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}