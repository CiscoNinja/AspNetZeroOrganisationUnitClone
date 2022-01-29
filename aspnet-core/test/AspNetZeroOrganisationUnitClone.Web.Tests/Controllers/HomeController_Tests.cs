using System.Threading.Tasks;
using AspNetZeroOrganisationUnitClone.Models.TokenAuth;
using AspNetZeroOrganisationUnitClone.Web.Controllers;
using Shouldly;
using Xunit;

namespace AspNetZeroOrganisationUnitClone.Web.Tests.Controllers
{
    public class HomeController_Tests: AspNetZeroOrganisationUnitCloneWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}