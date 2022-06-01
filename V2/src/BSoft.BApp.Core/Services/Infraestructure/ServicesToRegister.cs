// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using System.Collections.Generic;
using MGK.ServiceBase.Services.Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace BSoft.BApp.Core.Services.Infraestructure
{
    public class ServicesToRegister : IServicesToRegister
    {
        public ServicesToRegister(Dictionary<string, Type> dictionary, IServiceCollection serviceCollection)
        {
            _Dictionary = dictionary;
            _ServiceCollection = serviceCollection;
        }

        private Dictionary<string, Type> _Dictionary { get; }
        private IServiceCollection _ServiceCollection { get; set; }

        public void AddAsKeyedServices<TImplementedParentInterface>()
            where TImplementedParentInterface : class
        {
            _ServiceCollection.AddKeyedServices<TImplementedParentInterface, string>(_Dictionary);
        }
    }
}
