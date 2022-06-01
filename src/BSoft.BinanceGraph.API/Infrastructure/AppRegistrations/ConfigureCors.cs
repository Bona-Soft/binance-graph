using MGK.ServiceBase.SeedWork;
using BSoft.BinanceGraph.API.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace BSoft.BinanceGraph.API.Infrastructure.AppRegistrations
{
    public class ConfigureCors : IAppBuilderConfiguration
    {
        public void ConfigureApp(IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseCors(CoreConstants.CorsPolicy);
        }
    }
}
