// Copyright (c) BonaSoft, Inc. All rights reserved.

using System.Net.Http;

namespace BSoft.DemoApp.IntegrationTest.API.Controllers.Base
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
