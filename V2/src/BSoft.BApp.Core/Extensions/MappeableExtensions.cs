// Copyright (c) BonaSoft, Inc. All rights reserved.

using System.Collections.Generic;
using AutoMapper;
using BSoft.BApp.Core.Automapper.Interfaces;

namespace BSoft.BApp.Core.Automapper.Extensions
{
    public static class MappeableExtensions
    {
        internal static IMapper Mapper { get; set; }

        public static T Map<T>(this IBaseMappeable dto) => Mapper.Map<T>(dto);

        public static IEnumerable<T> Map<T>(this IEnumerable<IBaseMappeable> dto) => Mapper.Map<IEnumerable<T>>(dto);
    }
}
