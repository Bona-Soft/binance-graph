using MGK.ServiceBase.Services.SeedWork;

namespace BSoft.BApp.Services
{
	public interface IBaseInternalServices<T> : IInternalServices<T>
		where T : IBaseService
	{
	}
}
