using BSoft.BApp.Core.Controller;
using MediatR;

namespace BSoft.DemoApp.API.Application.Requests
{
	public record  UpdatePersonRequest
		(string Name,
		string Surname) 
		: BaseRequest, IRequest
	{
	}
}
