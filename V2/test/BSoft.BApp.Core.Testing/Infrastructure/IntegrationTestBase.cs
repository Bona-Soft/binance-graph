// Copyright (c) Zenfolio, Inc. All rights reserved.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Autofac;
using Moq;
using MoreLinq;
using Xunit;
using Xunit.Abstractions;
using Zenfolio.Common.Messaging.Infrastructure;

namespace BSoft.BApp.Core.Testing.Infrastructure
{
    [Collection(Constants.IntegrationTestsCollection)]
    public abstract class IntegrationTestBase : IDisposable
    {
        private readonly IntegrationTestHost _integrationTestHost;
        private readonly ConsoleConverter _consoleConverter;
        private readonly TextWriter _originalOut;
        private readonly TextWriter _originalError;

        private readonly IList<ILifetimeScope> _createdScopes = new List<ILifetimeScope>();

        private bool _disposed = false;

        protected IntegrationTestBase(
            ITestOutputHelper output,
            IntegrationTestFixtureBase integrationTestFixture,
            Action<ContainerBuilder> configurationAction = null)
        {
            _consoleConverter = new ConsoleConverter(output);

            // redirect console output and errors to xUnit test output
            _originalOut = Console.Out;
            _originalError = Console.Error;

            Console.SetOut(_consoleConverter);
            Console.SetError(_consoleConverter);

            Output = output;

            _integrationTestHost = integrationTestFixture.Host;
            TestScope = BeginTestScope(configurationAction);

            BusPublisherMock?.Reset();
        }

        ~IntegrationTestBase()
        {
            Dispose(false);
        }

        protected ITestOutputHelper Output { get; }

        protected ILifetimeScope TestScope { get; }

        protected Mock<IBusPublisher> BusPublisherMock => _integrationTestHost.BusPublisherMock;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected T Resolve<T>() => TestScope.Resolve<T>();

        protected ILifetimeScope BeginTestScope(Action<ContainerBuilder> configurationAction = null)
        {
            ILifetimeScope testScope = _integrationTestHost.BeginTestScope(configurationAction);
            _createdScopes.Add(testScope);

            return testScope;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            CleanUpAsync().GetAwaiter().GetResult();

            if (disposing)
            {
                _consoleConverter.Dispose();
                _createdScopes.ForEach(scope => scope.Dispose());
            }

            Console.SetOut(_originalOut);
            Console.SetError(_originalError);

            _disposed = true;
        }

        protected virtual Task CleanUpAsync() => Task.CompletedTask;
    }
}
