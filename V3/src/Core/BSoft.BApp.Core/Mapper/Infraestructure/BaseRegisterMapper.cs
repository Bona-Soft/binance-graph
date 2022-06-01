// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using AutoMapper;
using AutoMapper.Configuration;
using BSoft.BApp.Core.Automapper.Interfaces;
using BSoft.BApp.Core.Extensions;
using BSoft.BApp.Core.Infraestructure.Interfaces;
using BSoft.BApp.Core.Mapper.Infraestructure;
using MGK.ServiceBase.Registering.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BSoft.BApp.Core.Automapper.Infrastructure
{
    public class BaseRegisterMapper : RegisterMappingsBase, IBaseServiceRegistration
    {
        public int Order => 1;

        public void RegisterServices(IServiceCollection serviceProvider, IConfiguration configuration)
        {
            CreateMapper();
        }

        protected override IMapper CreateMapper()
        {
            var mappers = TypeExt.FindAllDerivedTypes<IBaseMapperProfile>();

            return new MapperConfiguration(config =>
            {
                config.AddProfile<BaseRegisterMapperProfile>();

                foreach (Type type in mappers)
                {
                    config.AddMaps(type.Assembly);
                }
            })
            .CreateMapper();
        }
    }
}
