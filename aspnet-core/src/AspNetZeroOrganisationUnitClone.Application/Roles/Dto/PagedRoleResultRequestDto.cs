using Abp.Application.Services.Dto;

namespace AspNetZeroOrganisationUnitClone.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

