// Copyright (c) Zenfolio, Inc. All rights reserved.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Npgsql;
using Refit;
using Zenfolio.Common.API.Mvc;
using Zenfolio.Common.Configuration;
using Zenfolio.Common.Contract.Interfaces;
using Zenfolio.Common.Contract.Types;
using Zenfolio.Common.Extensions;
using Zenfolio.Common.Utility;
using CommonConstants = Zenfolio.Common.Contract.Constants.Constants;
using HttpClientAutofacExtensions = Zenfolio.Common.HttpClient.AutofacExtensions;

namespace BSoft.BApp.Core.Testing.Infrastructure
{
    public static class Extensions
    {
        public static void WithRequestHeader(this ControllerBase controller, string name, string value)
            => controller.GetOrAddDefaultHttpContext().Request.Headers[name] = value;

        public static void WithUserId(this ControllerBase controller, Guid userId)
        {
            var userMock = new Mock<ClaimsPrincipal>();
            userMock.Setup(u => u.Claims).Returns(new Claim[] { new Claim(CommonConstants.ZenfolioUserIdClaimType, userId.ToString()) });

            controller.GetOrAddDefaultHttpContext().User = userMock.Object;
        }

        public static DefaultHttpContext GetOrAddDefaultHttpContext(this ControllerBase controller)
        {
            var defaultHttpContext = controller.ControllerContext.HttpContext as DefaultHttpContext;
            if (defaultHttpContext == null)
            {
                defaultHttpContext = new DefaultHttpContext();
                controller.ControllerContext.HttpContext = defaultHttpContext;
            }

            return defaultHttpContext;
        }

        public static void MappingProfileShouldBeValid(this Type mappingProfile)
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            IMapper mapper = config.CreateMapper();

            // Act
            Action act = () => mapper.ConfigurationProvider.AssertConfigurationIsValid();

            // Assert
            act.Should().NotThrow();
        }

        public static void RefitApiClientShouldBeValid(this Type httpClientType)
        {
            // Arrange
            const string sectionName = "HttpClient";

            var inMemorySettings = new Dictionary<string, string>
            {
                { $"{sectionName}:{nameof(HttpClientSettings.BaseAddress)}", "https://zenfolio.com/api" }
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(configuration);
            serviceCollection.AddSingleton<ICorrelationContextAccessor, CorrelationContextAccessor>();

            MethodInfo methodInfo = typeof(HttpClientAutofacExtensions).GetMethod(
                nameof(HttpClientAutofacExtensions.AddRefitHttpClient),
                BindingFlags.Public | BindingFlags.Static,
                null,
                new[] { typeof(IServiceCollection), typeof(IConfiguration), typeof(string) },
                null).MakeGenericMethod(httpClientType);

            methodInfo.Invoke(null, new object[] { serviceCollection, configuration, sectionName });

            using (ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider())
            {
                // Act
                string error = string.Empty;

                try
                {
                    serviceProvider.GetRequiredService(httpClientType);
                }
                catch (Exception ex)
                {
                    error = ex.ToString();
                }

                // Assert
                error.Should().BeEmpty();
            }
        }

        public static async Task PrepareSqlServerDatabaseAsync<TContext>(this ILifetimeScope testScope, bool migrate)
            where TContext : EntityFramework.DbContextBase
        {
            TContext context = testScope.ResolveOptional<TContext>();
            if (context != null)
            {
                await context.Database.EnsureDeletedAsync();

                if (migrate)
                {
                    await context.Database.MigrateAsync();
                }
            }
        }

        public static async Task PreparePostgreSqlDatabaseAsync<TContext>(this ILifetimeScope testScope, bool migrate)
            where TContext : EntityFramework.PostgreSql.DbContextBase
        {
            TContext context = testScope.ResolveOptional<TContext>();
            if (context != null)
            {
                await context.Database.EnsureDeletedAsync();

                if (migrate)
                {
                    await context.Database.MigrateAsync();

                    // https://github.com/npgsql/efcore.pg/issues/292#issuecomment-388608426
                    await context.Database.OpenConnectionAsync();
                    ((NpgsqlConnection)context.Database.GetDbConnection()).ReloadTypes();
                }
            }
        }

        public static async Task<ApiException> ToRefitApiExceptionAsync(
            this ZenfolioException exception,
            HttpStatusCode? statusCode = null,
            HttpMethod httpMethod = null,
            bool includeStackTrace = false)
#pragma warning disable CA2000 // Dispose objects before losing scope
            => await ApiException.Create(
                new HttpRequestMessage(),
                httpMethod ?? HttpMethod.Get,
                new HttpResponseMessage(statusCode ?? HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(exception.ToOperationProblemDetails(includeStackTrace).SerializeToJson())
                });
#pragma warning restore CA2000 // Dispose objects before losing scope
    }
}
