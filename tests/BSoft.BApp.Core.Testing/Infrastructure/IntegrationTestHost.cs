// Copyright (c) Zenfolio, Inc. All rights reserved.

using System;
using System.Threading.Tasks;
using Autofac;
using EnsureThat;
using Moq;
using Nito.AsyncEx;
using Zenfolio.Common.Configuration;
using Zenfolio.Common.Configuration.Environment;
using Zenfolio.Common.Extensions;
using Zenfolio.Common.GenericHostBuilder;
using Zenfolio.Common.Messaging.Infrastructure;

namespace BSoft.BApp.Core.Testing.Infrastructure
{
    public sealed class IntegrationTestHost : IDisposable
    {
        private readonly Action<ServiceBuilder> _registerDependencies;
        private readonly Func<ILifetimeScope, Task> _setUpAsync;
        private readonly Func<ILifetimeScope, Task> _tearDownAsync;

        private readonly bool _mockBusPublisher;
        private readonly Task _hostTask;
        private readonly AsyncManualResetEvent _hostStopped;

        private ILifetimeScope _rootScope;

        public IntegrationTestHost(
            string serviceTypeName,
            Action<ServiceBuilder> registerDependencies,
            Func<ILifetimeScope, Task> setUpAsync = null,
            Func<ILifetimeScope, Task> tearDownAsync = null,
            bool mockBusPublisher = true
            )
        {
            Ensure.String.IsNotNullOrWhiteSpace(serviceTypeName, nameof(serviceTypeName));
            Ensure.Any.IsNotNull(registerDependencies, nameof(registerDependencies));

            _registerDependencies = registerDependencies;
            _setUpAsync = setUpAsync;
            _tearDownAsync = tearDownAsync;
            _mockBusPublisher = mockBusPublisher;

            _hostStopped = new AsyncManualResetEvent(set: false);

            _hostTask = GenericHostUtils.RunHostAsync(
                serviceTypeName,
                BuildIntegrationTestHostAsync,
                RegisterIntegrationTestDependencies);

            if (_hostTask.IsFaulted)
            {
                // re-throw exception if host task failed on startup
                AwaitHostTask();
            }
        }

        public Mock<IBusPublisher> BusPublisherMock { get; private set; }

        public void Dispose()
        {
            TearDownAsync().GetAwaiter().GetResult();

            _hostStopped.Set();
            AwaitHostTask();
        }

        public ILifetimeScope BeginTestScope(Action<ContainerBuilder> configurationAction = null)
        {
            return _rootScope.BeginLifetimeScope(builder =>
            {
                // allow any types (e.g. controllers, services, repositories) to be resolved through Autofac
                builder.AllowAnyConcreteType(typeof(object));

                // optionally register any additional test dependencies
                configurationAction?.Invoke(builder);
            });
        }

        private async Task BuildIntegrationTestHostAsync(
            ILifetimeScope rootScope,
            IWorkingEnvironment workingEnvironment)
        {
            Ensure.Any.IsNotNull(rootScope, nameof(rootScope));
            Ensure.Any.IsNotNull(workingEnvironment, nameof(workingEnvironment));

            // only allow running integration tests in the corresponding environment
            Ensure.Bool.IsTrue(workingEnvironment.CanRunIntegrationTests(), nameof(workingEnvironment));

            _rootScope = rootScope;

            SetUpAsync().GetAwaiter().GetResult();

            await _hostStopped.WaitAsync();
        }

        private void RegisterIntegrationTestDependencies(ServiceBuilder serviceBuilder)
        {
            _registerDependencies(serviceBuilder);

            if (_mockBusPublisher)
            {
                BusPublisherMock = new Mock<IBusPublisher>();

                // override Service Bus publisher registration with mock
                serviceBuilder.ContainerBuilder.RegisterInstance(BusPublisherMock.Object).As<IBusPublisher>();
            }
        }

        private async Task SetUpAsync()
        {
            using (ILifetimeScope testScope = BeginTestScope())
            {
                await PrepareDatabaseAsync(testScope, migrate: true);

                if (_setUpAsync != null)
                {
                    await _setUpAsync(testScope);
                }
            }
        }

        private async Task TearDownAsync()
        {
            using (ILifetimeScope testScope = BeginTestScope())
            {
                if (_tearDownAsync != null)
                {
                    await _tearDownAsync(testScope);
                }

                await PrepareDatabaseAsync(testScope, migrate: false);
            }
        }

        private async Task PrepareDatabaseAsync(ILifetimeScope testScope, bool migrate)
        {
            await testScope.PrepareSqlServerDatabaseAsync<EntityFramework.DbContextBase>(migrate);
            await testScope.PreparePostgreSqlDatabaseAsync<EntityFramework.PostgreSql.DbContextBase>(migrate);
        }

        private void AwaitHostTask() => _hostTask.GetAwaiter().GetResult();
    }
}
