using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGK.ServiceBase.DAL.SeedWork;

namespace BSoft.BinanceGraph.DataAccess.Infrastructure.Queries
{
    public interface IBaseQueryBuilder<TEntity,TQueryBuilder> : IQueryBuilder<TEntity, TQueryBuilder>
        where TEntity : IDataUnit
        where TQueryBuilder : IQueryBuilder
    {
    }
}
