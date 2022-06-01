// Copyright (c) BonaSoft, Inc. All rights reserved.

using AutoMapper;
using BSoft.BApp.Core.Infraestructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace BSoft.BApp.Core.Controller.Interfaces
{
    public interface IBaseCommonControllerServices<TController>
    {
        IMapper Mapper { get; }

        ILogger<TController> Logger { get; }

        IBaseServiceProvider ManagerServiceProvider { get; }
    }
}
