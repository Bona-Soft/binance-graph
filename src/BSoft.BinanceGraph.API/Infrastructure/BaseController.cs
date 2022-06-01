using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BSoft.BinanceGraph.API.Infrastructure
{
    public class BaseController<TController> : ControllerBase
    {

        public BaseController(
            ICommonControllerServices<TController> commonControllerServices)
        {
            Logger = commonControllerServices.Logger;
            Mapper ??= commonControllerServices.Mapper;
        }

        protected static IMapper Mapper { get; private set; }

        protected ILogger<TController> Logger { get; }
    }
}
