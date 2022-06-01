// Copyright (c) BonaSoft, Inc. All rights reserved.

using BSoft.BinanceGraph.DataAccess.Infrastructure.Enums;
using MGK.ServiceBase.DAL.Infrastructure.Factories;

namespace BSoft.BinanceGraph.DataAccess.Contexts
{
    public class BinanceGraphContextDesignFactory : CustomDbContextDesignFactory<BinanceGraphContext>
    {
        protected override string AppSettingsFile => "appsettings.local.json";

        protected override string DbName => nameof(AvailableDatabase.BinanceGraph);
    }
}
