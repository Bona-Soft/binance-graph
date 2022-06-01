using MGK.ServiceBase.CQRS.SeedWork;

namespace BSoft.DemoApp.API.Models
{
	public record ResponseViewModel 
		(string Message,
		object Data)
		: IResponse, IContract
	{
	}
}
