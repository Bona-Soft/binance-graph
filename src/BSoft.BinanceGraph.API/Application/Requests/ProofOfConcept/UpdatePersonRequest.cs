using MediatR;

namespace BSoft.BinanceGraph.API.Application.Requests.ProofOfConcept
{
	public class UpdatePersonRequest : IRequest
	{
		public string Name { get; set; }

		public string Surname { get; set; }

		public UpdatePersonRequest()
		{
		}
	}
}
