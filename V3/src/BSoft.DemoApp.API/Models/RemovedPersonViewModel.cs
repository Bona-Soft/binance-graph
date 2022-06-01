using MGK.ServiceBase.CQRS.SeedWork;
using BSoft.DemoApp.API.Infrastructure.Contracts.ProofOfConcept;
using BSoft.BApp.Core.Automapper.Interfaces;

namespace BSoft.DemoApp.API.Models.ProofOfConcept
{
	public record RemovedPersonViewModel 
		(string Fullname,
		string DocumentNumber) : IPersonContract, IResponse, IBaseMappeable
	{
	}
}
