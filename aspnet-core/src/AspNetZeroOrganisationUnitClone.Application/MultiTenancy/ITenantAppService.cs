using Abp.Application.Services;
using AspNetZeroOrganisationUnitClone.MultiTenancy.Dto;

namespace AspNetZeroOrganisationUnitClone.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

