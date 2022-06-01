using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BSoft.BApp.Core.Interfaces;

namespace BSoft.BApp.Core.Automapper.Extensions
{
    public static class MappeableExtensions
    {
        private static IMapper Mapper { get; set; }

        public static T Map<T>(this IMappeable dto) => Mapper.Map<T>(dto);
        public static IEnumerable<T> Map<T>(this IEnumerable<IMappeable> dto) => Mapper.Map<IEnumerable<T>>(dto);
    }
}
