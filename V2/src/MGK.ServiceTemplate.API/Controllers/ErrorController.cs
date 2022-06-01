// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using System.Diagnostics;
using BSoft.BApp.Core.Exceptions;
using BSoft.BApp.Core.Infraestructure;
using BSoft.DemoApp.API.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BSoft.DemoApp.API.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        [Route(BaseEnviroments.Production.ErrorPath)]
        public BaseError Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;
            Response.StatusCode = 500;

            if (exception is BaseException)
            {
                var baseException = (BaseException)exception;
                Response.StatusCode = baseException.StatusCode;
                return (BaseError)exception;
            }

            return (BaseError)exception; 
        }

        [Route(BaseEnviroments.Development.ErrorPath)]
        public Exception ErrorDeveloper()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;
            Response.StatusCode = 500;

            if (exception is BaseException)
            {
                var baseException = (BaseException)exception;
                Response.StatusCode = baseException.StatusCode;
            }

            return exception;
        }
    }
}
