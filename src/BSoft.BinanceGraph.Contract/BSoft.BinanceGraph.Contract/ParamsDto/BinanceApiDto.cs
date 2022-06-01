using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSoft.BApp.Core.Interfaces;

namespace BSoft.BinanceGraph.Contract.ParamsDto
{
    public class BinanceApiDto : IMappeable
    {
        public Guid? Id { get; set; }
        public string ApiKey { get; set; }
        public string SecretKey { get; set; }
    }
}
