using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSoft.BinanceGraph.Contract.Interfaces.Accesor
{
    public interface IQueryBuilders
    {
        public T Resolve<T>();
    }
}
