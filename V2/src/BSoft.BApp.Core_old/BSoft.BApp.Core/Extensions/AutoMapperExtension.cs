// Copyright (c) Zenfolio, Inc. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace BSoft.BApp.Core.Automapper.Extensions
{
    public static class AutoMapperExtension
    {
        public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            Type sourceType = typeof(TSource);
            PropertyInfo[] destinationProperties = typeof(TDestination).GetProperties(flags);

            foreach (PropertyInfo property in destinationProperties)
            {
                if (sourceType.GetProperty(property.Name, flags) == null)
                {
                    expression.ForMember(property.Name, opt => opt.Ignore());
                }
            }

            return expression;
        }

        public static IMappingExpression IgnoreAllNonExisting(this IMappingExpression expression, Type sourceType, Type destination)
        {
            BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            PropertyInfo[] destinationProperties = destination.GetProperties(flags);

            foreach (PropertyInfo property in destinationProperties)
            {
                if (sourceType.GetProperty(property.Name, flags) == null)
                {
                    expression.ForMember(property.Name, opt => opt.Ignore());
                }
            }

            return expression;
        }
    }
}
