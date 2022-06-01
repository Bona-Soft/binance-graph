using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using BSoft.BApp.Core.Exceptions;
using BSoft.BApp.Core.Infraestructure;

namespace BSoft.DemoApp.Contract.Errors
{
    public static class Errors
    {
        public static class PersonAlreadyExists
        {
            public const string Code = "person_already_exists";
            public const string Title = "Person already exists..";
            public const string Message = "Person with dni {0} already exists.";
            public const int StatusCode = StatusCodes.Status409_Conflict;

            public static readonly BaseError Error = new BaseError(Code, Title, Message, StatusCode);
        }

        public static class PersonNotFound
        {
            public const string Code = "person_not_exists";
            public const string Title = "Person not found.";
            public const string Message = "Person not found.";
            public const int StatusCode = StatusCodes.Status409_Conflict;

            public static readonly BaseError Error = new BaseError(Code, Title, Message, StatusCode);
        }
    }
}
