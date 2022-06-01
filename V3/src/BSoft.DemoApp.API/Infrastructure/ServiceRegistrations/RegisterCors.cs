using MGK.ServiceBase.Services.SeedWork;
using BSoft.DemoApp.API.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BSoft.BApp.Core.Infraestructure.Interfaces;

namespace BSoft.DemoApp.API.Infrastructure.ServiceRegistrations
{
    public class RegisterCors : IBaseServiceRegistration
    {
        public int Order => 2;

        public void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
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
