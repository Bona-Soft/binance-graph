using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSoft.BinanceGraph.Contract.Interfaces.Accesor;
using MGK.ServiceBase.DAL.SeedWork;

namespace BSoft.BinanceGraph.DataAccess.Infraestructure.Queries
{
    public class QueryBuilders : IQueryBuilders
    {
        private readonly QueryProviderFactory _qProvider;

        public delegate IQueryBuilder QueryProviderFactory(string key);

        public QueryBuilders(QueryProviderFactory queryProvider)
        {
            _qProvider = queryProvider;
        }

        public T Resolve<T>()
        {
            return (T)_qProvider(typeof(T).Name);
        }
    }
}
