using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BSoft.BApp.Core.Extensions
{
    public static class EnviromentExt
    {
        public static bool IsLocal(this IWebHostEnvironment env)
        {
            return env.IsEnvironment("Local")
                || env.IsEnvironment("LOCAL")
                || env.IsEnvironment("local");
        }
    }
}
