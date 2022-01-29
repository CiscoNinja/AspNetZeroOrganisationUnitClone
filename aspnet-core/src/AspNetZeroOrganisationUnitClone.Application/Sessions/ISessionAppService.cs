using System.Threading.Tasks;
using Abp.Application.Services;
using AspNetZeroOrganisationUnitClone.Sessions.Dto;

namespace AspNetZeroOrganisationUnitClone.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
