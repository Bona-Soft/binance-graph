using MGK.ServiceBase.SeedWork;
using BSoft.BinanceGraph.API.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BSoft.BApp.Core.Interfaces;

namespace BSoft.BinanceGraph.API.Infrastructure.ServiceRegistrations
{
    public class RegisterCors : IServiceRegistration
    {
        public int Order => 1;

        public void RegisterServices(IServiceCollection serviceProvider, IConfiguration configuration)
        {
            serviceProvider.AddCors(options =>
            {
                options.AddPolicy(
                    CoreConstants.CorsPolicy,
                    builder => builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .SetIsOriginAllowed(_ => true));
            });
        }
    }
}
