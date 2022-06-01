// Copyright (c) BonaSoft, Inc. All rights reserved.

using AutoMapper;
using BSoft.BApp.Core.Controller.Interfaces;
using BSoft.BApp.Core.Infraestructure.Interfaces;
using BSoft.BApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BSoft.BApp.Core.Controller
{
    public class BaseController<TController, TService> : ControllerBase
        where TService : class, IBaseService
    {
        public TService Service => BaseServiceProvider.Get<TService>();

        public BaseController(
            IBaseCommonControllerServices<TController> commonControllerServices)
        {
            Logger = commonControllerServices.Logger;
            Mapper ??= commonControllerServices.Mapper;
            BaseServiceProvider = commonControllerServices.ManagerServiceProvider;
        }

        protected static IMapper Mapper { get; private set; }

        protected static T Map<T>(object source) => Mapper.Map<T>(source);

        protected ILogger<TController> Logger { get; }

        protected TOutputService Services<TOutputService>()
            where TOutputService : class, IBaseService
        {
            return BaseServiceProvider.Get<TOutputService>();
        }

        protected IBaseServiceProvider BaseServiceProvider { get; }
    }
}
