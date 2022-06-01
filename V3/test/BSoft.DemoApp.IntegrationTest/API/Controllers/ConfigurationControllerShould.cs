// Copyright (c) BonaSoft, Inc. All rights reserved.

using System.Threading.Tasks;
using BSoft.BinanceGraph.API.Controllers;
using BSoft.BinanceGraph.IntegrationTest.API.Controllers.Base;
using Xunit;

namespace BSoft.BinanceGraph.IntegrationTest.API.Controllers
{
    public class ConfigurationControllerShould : ControllerShouldBase<ConfigurationController>
    {
        public ConfigurationControllerShould(IntegrationTestFixture testFixture)
            : base (testFixture)
        {
        }

        [Fact]
        public async Task GetAllApiConfiguration_Should_RetrieveAll()
        {
            var response = await Client.GetAsync(ConfigurationController.Routes.Get_AllApiConfiguration);
            var response2 = await Controller.GetAllApiConfiguration();

            //response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
