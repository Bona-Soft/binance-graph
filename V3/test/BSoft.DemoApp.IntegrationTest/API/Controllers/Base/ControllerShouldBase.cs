// Copyright (c) BonaSoft, Inc. All rights reserved.

using System.Net.Http;
using BSoft.BinanceGraph.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace BSoft.BinanceGraph.IntegrationTest.API.Controllers.Base
{
    public abstract class ControllerShouldBase<T>
    {
        protected static HttpClient Client { get; private set; }

        protected T Controller { get; set; }

        protected ControllerShouldBase(IntegrationTestFixture testFixture)
        {
            Client = testFixture.Client;
        }
    }
}
