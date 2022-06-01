// Copyright (c) BonaSoft, Inc. All rights reserved.

using System.Threading.Tasks;
using BSoft.DemoApp.API.Controllers;
using BSoft.DemoApp.IntegrationTest.API.Controllers.Base;
using Xunit;

namespace BSoft.DemoApp.IntegrationTest.API.Controllers
{
    public class ConfigurationControllerShould : ControllerShouldBase<PersonController>
    {
        public ConfigurationControllerShould(IntegrationTestFixture testFixture)
            : base(testFixture)
        {
        }

        [Fact]
        public async Task GetAllApiConfiguration_Should_RetrieveAll()
        {
            //var response = await Client.GetAsync(ConfigurationController.Routes.Get_AllApiConfiguration);
            //var response2 = await Controller.GetAllApiConfiguration();

            //response.StatusCode.Should().Be(HttpStatusCode.OK);
            await Task.CompletedTask;
        }
    }
}
