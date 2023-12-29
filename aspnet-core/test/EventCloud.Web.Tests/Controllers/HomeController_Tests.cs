using System.Threading.Tasks;
using EventCloud.Models.TokenAuth;
using EventCloud.Web.Controllers;
using Shouldly;
using Xunit;

namespace EventCloud.Web.Tests.Controllers
{
    public class HomeController_Tests: EventCloudWebTestBase
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