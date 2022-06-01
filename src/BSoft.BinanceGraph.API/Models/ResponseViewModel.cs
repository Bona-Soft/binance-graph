using MGK.ServiceBase.CQRS.SeedWork;

namespace BSoft.BinanceGraph.API.Models
{
	public class ResponseViewModel : IResponse, IContract
	{
		public string Message { get; set; }

		public object Data { get; set; }
	}
}
