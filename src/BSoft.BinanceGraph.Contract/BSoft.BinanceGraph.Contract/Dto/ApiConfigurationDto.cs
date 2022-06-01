using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSoft.BinanceGraph.Contract.Enums;

namespace BSoft.BinanceGraph.Contract.Dto
{
    public class ApiConfigurationDto : BaseDto
    {
        public string ApiKey { get; set; }
        public string SecretKey { get; set; }
        public ApiProvider ApiProvider { get; set; }
    }
}
