// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BSoft.BinanceGraph.Contract.Dto;
using BSoft.BinanceGraph.Contract.Interfaces.Manager.Base;
using BSoft.BinanceGraph.Contract.ParamsDto;

namespace BSoft.BinanceGraph.Contract.Interfaces.Manager
{
    public interface IApiConfigurationService : IService
    {
        Task<ApiConfigurationDto> GetApiConfigurationById(Guid Id);

        Task<IEnumerable<ApiConfigurationDto>> GetAllConfigurations();

        Task<ApiConfigurationDto> AddBinanceApi(BinanceApiDto keys);

        Task<ApiConfigurationDto> RemoveApiConfiguration(Guid id);

        Task<ApiConfigurationDto> UpdateApiConfiguration(BinanceApiDto dto);
    }
}
