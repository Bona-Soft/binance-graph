using MGK.ServiceBase.Infrastructure.Extensions;
using BSoft.BinanceGraph.DataAccess.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BSoft.BinanceGraph.Contract.Interfaces.Manager.Base;
using BSoft.BApp.Core.Interfaces;

namespace BSoft.BinanceGraph.Manager.Infrastructure.Extensions
{
    public class ServiceRegistrationExtensions : IBaseServiceRegistration
    {
        public int Order => 2;

        public void RegisterServices(IServiceCollection serviceProvider, IConfiguration configuration)
        {
            serviceProvider.AddServicesInAssembly<MappingProfile>(configuration);
            serviceProvider.AddServicesInAssembly<IService>(configuration);
        }

    }
}
