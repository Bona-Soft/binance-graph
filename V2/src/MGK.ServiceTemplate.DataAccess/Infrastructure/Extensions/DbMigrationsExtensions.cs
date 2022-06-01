using BSoft.DemoApp.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BSoft.DemoApp.DataAccess.Infrastructure.Extensions
{
	public static class DbMigrationsExtensions
    {
        public static void RunDbMigrations(this IServiceCollection services)
        {
            using var serviceProvider = services.BuildServiceProvider();
            serviceProvider.Run<Contexts.AppContext>();
		}

        private static void Run<TContext>(this IServiceProvider serviceProvider)
            where TContext : DbContext
        {
            using var context = serviceProvider.GetRequiredService<TContext>();
            context.Database.Migrate();
        }
    }
}
