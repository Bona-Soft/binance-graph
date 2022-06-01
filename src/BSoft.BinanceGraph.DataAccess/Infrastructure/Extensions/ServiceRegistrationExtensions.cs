using BSoft.BApp.Core.Interfaces;
using MGK.ServiceBase.DAL.Infrastructure.Extensions;
using MGK.ServiceBase.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BSoft.BinanceGraph.DataAccess.Infrastructure.Extensions
{
    public class ServiceRegistrationExtensions : IServiceRegistration
    {
        public int Order => 3;
        public void RegisterServices(IServiceCollection serviceProvider, IConfiguration configuration)
        {
            serviceProvider.AddDALServices(configuration);
            serviceProvider.AddServicesInAssembly<MappingProfile>(configuration);
        }
    }
}
