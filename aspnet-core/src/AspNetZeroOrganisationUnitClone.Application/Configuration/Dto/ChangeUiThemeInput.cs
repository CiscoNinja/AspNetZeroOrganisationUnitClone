using System.ComponentModel.DataAnnotations;

namespace AspNetZeroOrganisationUnitClone.Configuration.Dto
{
    public class ChangeUiThemeInput
    {
        [Required]
        [StringLength(32)]
        public string Theme { get; set; }
    }
}
