// Copyright (c) BonaSoft, Inc. All rights reserved.

namespace BSoft.BApp.Core.Services.Infraestructure
{
    public interface IServicesToRegister
    {
        void AddAsKeyedServices<TImplementedParentInterface>()
            where TImplementedParentInterface : class;
    }
}
