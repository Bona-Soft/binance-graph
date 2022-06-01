// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BSoft.BApp.Core.Automapper.Extensions;
using BSoft.BinanceGraph.Contract.Dto;
using BSoft.BinanceGraph.Contract.Interfaces.Manager;
using BSoft.BinanceGraph.Contract.ParamsDto;
using BSoft.BinanceGraph.DataAccess.Queries.Interfaces;
using BSoft.BinanceGraph.Entities;
using BSoft.BinanceGraph.Manager.Interfaces;
using BSoft.BinanceGraph.Manager.Services.Base;
using MGK.Acceptance;
using MGK.Extensions;
using MGK.ServiceBase.Infrastructure.Exceptions;

namespace BSoft.BinanceGraph.Manager.Services
{
    public class ConfigurationService : ServiceBase<ConfigurationService>, IApiConfigurationService
    {
        public ConfigurationService(ICommonServices<ConfigurationService> cs)
            : base(cs)
        {
        }

        public async Task<ApiConfigurationDto> GetApiConfigurationById(Guid Id)
        {
            return (await QB<IApiConfigurationQueryBuilder>()
                .Start()
                .FilterById(Id)
                .GetRecordAsync())
                .Map<ApiConfigurationDto>();
        }

        public async Task<IEnumerable<ApiConfigurationDto>> GetAllConfigurations()
        {
            return (await QB<IApiConfigurationQueryBuilder>()
                .Start()
                .QueryAsEnumerableAsync<ApiConfiguration>())
                .Map<ApiConfigurationDto>();
        }

        public async Task<ApiConfigurationDto> AddBinanceApi(BinanceApiDto keys)
        {
            Ensure.Parameter.IsNotNull(keys, nameof(keys));

            ApiConfiguration apiConfig = UnitOfWork.Add(keys.Map<ApiConfiguration>());
            await UnitOfWork.CommitChangesAsync();

            return apiConfig.Map<ApiConfigurationDto>();
        }

        public async Task<ApiConfigurationDto> RemoveApiConfiguration(Guid id)
        {
            var config = await GetApiConfigurationById(id);

            if (config == null)
            {
                Raise.Error.Generic<ServiceValidationException>(
                    ManagerResources.MessagesResources.ErrorNotExists,
                    ManagerResources.MessagesResources.ErrorNotExistsDetails.Format(id));
            }

            UnitOfWork.RemoveByIds<ApiConfiguration>(id);
            await UnitOfWork.CommitChangesAsync();

            return config.Map<ApiConfigurationDto>();
        }

        public async Task<ApiConfigurationDto> UpdateApiConfiguration(BinanceApiDto dto)
        {
            Ensure.Parameter.IsNotNull(dto, nameof(dto));

            var apiConfig = await QB<IApiConfigurationQueryBuilder>()
                .Start()
                .FilterById(dto.Id.Value)
                .GetRecordAsync(true);

            if (apiConfig == null)
            {
                Raise.Error.Generic<ServiceValidationException>(
                    ManagerResources.MessagesResources.ErrorNotExists,
                    ManagerResources.MessagesResources.ErrorNotExistsDetails.Format(dto.Id));
            }
            apiConfig = Mapper.Map<ApiConfiguration>(dto);
            apiConfig.LastUpdateDate = DateTime.UtcNow;

            await UnitOfWork.CommitChangesAsync();

            return apiConfig.Map<ApiConfigurationDto>();
        }
    }
}
