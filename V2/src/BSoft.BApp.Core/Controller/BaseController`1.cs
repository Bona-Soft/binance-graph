// Copyright (c) BonaSoft, Inc. All rights reserved.

using AutoMapper;
using BSoft.BApp.Core.Controller.Interfaces;
using BSoft.BApp.Core.Infraestructure.Interfaces;
using BSoft.BApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BSoft.BApp.Core.Controller
{
    public class BaseController<TController> : ControllerBase
    {
        public BaseController(
            IBaseCommonControllerServices<TController> commonControllerServices)
        {
            Logger = commonControllerServices.Logger;
            Mapper ??= commonControllerServices.Mapper;
            BaseServiceProvider = commonControllerServices.ManagerServiceProvider;
        }

        protected static IMapper Mapper { get; private set; }

        protected ILogger<TController> Logger { get; }

        protected TOutputService Services<TOutputService>()
            where TOutputService : class, IBaseService
        {
            return BaseServiceProvider.Get<TOutputService>();
        }

        protected IBaseServiceProvider BaseServiceProvider { get; }
    }
}
