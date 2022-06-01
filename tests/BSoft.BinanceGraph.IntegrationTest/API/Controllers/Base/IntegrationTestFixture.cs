// Copyright (c) BonaSoft, Inc. All rights reserved.

using System.Net.Http;
using BSoft.DemoApp.API;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace BSoft.DemoApp.IntegrationTest.API.Controllers.Base
{
    public class IntegrationTestFixture : IClassFixture<WebApplicationFactory<Startup>>
    {
        public HttpClient Client { get; private set; }
        protected static WebApplicationFactory<Startup> Factory { get; private set; }

        protected IntegrationTestFixture(WebApplicationFactory<Startup> factory)
        {
            if (Factory != null)
            {
                Factory = factory;

                if (Client != null)
                {
                    Client = factory.CreateClient();
                }
            }
        }
    }
}
