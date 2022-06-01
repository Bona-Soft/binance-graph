// Copyright (c) BonaSoft, Inc. All rights reserved.

using BSoft.BinanceGraph.DataAccess.Contexts;
using BSoft.BinanceGraph.DataAccess.Infrastructure.UnitOfWork;
using MGK.ServiceBase.DAL.Infrastructure.UnitOfWork;

namespace BSoft.BinanceGraph.DataAccess.UnitOfWork
{
    public class BinanceUoW : UnitOfWork<BinanceGraphContext>, IBinanceUoW
    {
        public BinanceUoW(BinanceGraphContext context)
            : base(context)
        {
        }
    }
}
