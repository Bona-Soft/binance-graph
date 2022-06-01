using AutoMapper;
using MGK.ServiceBase.Registering.Service;

namespace BSoft.BinanceGraph.API.Infrastructure.ServiceRegistrations
{
	public class RegisterMappings : RegisterMappingsBase
	{
		protected override IMapper CreateMapper()
		{
			return new MapperConfiguration(config =>
			{
				config.AddMaps(typeof(MappingProfile).Assembly);
				//config.AddMaps(ManagerMappingsHelper.GetMappingsAssemblies());
			})
			.CreateMapper();
		}
	}
}
