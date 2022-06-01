// Copyright (c) Zenfolio, Inc. All rights reserved.

using System;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Zenfolio.Common.Configuration;

namespace BSoft.BApp.Core.Testing.Infrastructure
{
    public abstract class IntegrationTestFixtureBase : IDisposable
    {
        private readonly Lazy<IntegrationTestHost> _lazyHost;
        private bool _disposed = false;

        protected IntegrationTestFixtureBase(
            string serviceTypeName,
            Action<ServiceBuilder> registerDependencies,
            Func<ILifetimeScope, Task> setUpAsync = null,
            Func<ILifetimeScope, Task> tearDownAsync = null,
            bool mockBusPublisher = true
            )
        {
            _lazyHost = new Lazy<IntegrationTestHost>(
                () => new IntegrationTestHost(
                    serviceTypeName, registerDependencies, setUpAsync, tearDownAsync, mockBusPublisher),
                LazyThreadSafetyMode.ExecutionAndPublication);
        }

        ~IntegrationTestFixtureBase()
        {
            Dispose(false);
        }

        public IntegrationTestHost Host => _lazyHost.Value;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                if (_lazyHost.IsValueCreated)
                {
                    _lazyHost.Value.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
