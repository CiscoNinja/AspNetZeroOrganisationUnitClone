using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AspNetZeroOrganisationUnitClone.MyOrganizationUnit.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetZeroOrganisationUnitClone.MyOrganizationUnit
{
    public interface IOrganisationUnitAppService : IAsyncCrudAppService<MyOrganizationUnitDto, long, PagedAndSortedResultRequestDto, CreateMyOrganizationUnitDto, MyOrganizationUnitDto>
    {
        //Task<OrganizationUnitDto> CreateOU(CreateOrganizationUnitDto organizationUnit);
        List<OUListDto> GetFileStructure();
        List<OUListDto> BuildTree(List<OUListDto> list);
        Task<OUListDto> GetByIDAsync(long id);
    }
}
