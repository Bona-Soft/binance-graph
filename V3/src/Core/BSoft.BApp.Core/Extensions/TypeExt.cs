// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BSoft.BApp.Core.Extensions
{
    public static class TypeExt
    {
        public static IEnumerable<Type> FindAllDerivedTypesFrom<T>()
        {
            return FindAllDerivedTypes<T>(Assembly.GetAssembly(typeof(T)));
        }

        public static IEnumerable<Type> FindAllDerivedTypes<T>(string solutionName = null)
        {
            IEnumerable<Assembly> assemblies = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Where(x =>
                    string.IsNullOrEmpty(solutionName)
                    || x.FullName.Contains(solutionName, StringComparison.Ordinal)
                    || x.FullName.Contains("BSoft", StringComparison.Ordinal));

            return assemblies.SelectMany(x => FindAllDerivedTypes<T>(x));
        }

        public static IEnumerable<Type> FindAllDerivedTypes<T>(Func<Type, bool> predicate, string solutionName = null)
        {
            IEnumerable<Assembly> assemblies = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Where(x =>
                    string.IsNullOrEmpty(solutionName)
                    || x.FullName.Contains(solutionName, StringComparison.Ordinal)
                    || x.FullName.Contains("BSoft", StringComparison.Ordinal));

            return assemblies.SelectMany(x => FindAllDerivedTypes<T>(x, predicate));
        }

        public static IEnumerable<Type> FindAllDerivedTypes<T>(Assembly assembly)
        {
            Type derivedType = typeof(T);

            return assembly
                .GetLoadableTypes()
                .Where(t =>
                    t != derivedType &&
                    derivedType.IsAssignableFrom(t));
        }

        public static IEnumerable<Type> FindAllDerivedTypes<T>(Assembly assembly, Func<Type, bool> predicate)
        {
            Type derivedType = typeof(T);
            return assembly
                .GetLoadableTypes()
                .Where(t =>
                    t != derivedType &&
                    derivedType.IsAssignableFrom(t))
                .Where(predicate);
        }

        public static IEnumerable<Type> FindAllDerivedTypes(this Type type, string solutionName = null)
        {
            IEnumerable<Assembly> assemblies = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Where(x =>
                    string.IsNullOrEmpty(solutionName)
                    || x.FullName.Contains(solutionName, StringComparison.Ordinal)
                    || x.FullName.Contains("BSoft", StringComparison.Ordinal));

            return assemblies.SelectMany(x => FindAllDerivedTypes(type, x));
        }

        public static IEnumerable<Type> FindAllDerivedTypes(this Type type, Func<Type, bool> predicate, string solutionName = null)
        {
            IEnumerable<Assembly> assemblies = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Where(x =>
                    string.IsNullOrEmpty(solutionName)
                    || x.FullName.Contains(solutionName, StringComparison.Ordinal)
                    || x.FullName.Contains("BSoft", StringComparison.Ordinal));

            return assemblies.SelectMany(x => FindAllDerivedTypes(type, x, predicate));
        }

        public static IEnumerable<Type> FindAllDerivedTypesFrom(this Type type)
            => type.FindAllDerivedTypes(Assembly.GetAssembly(type));

        public static IEnumerable<Type> FindAllDerivedTypesFrom(this Type type, Func<Type, bool> predicate)
            => type.FindAllDerivedTypes(Assembly.GetAssembly(type), predicate);

        public static IEnumerable<Type> FindAllDerivedTypes(this Type type, Assembly assembly)
        {
            return assembly
                .GetLoadableTypes()
                .Where(t =>
                    t != type &&
                    type.IsAssignableFrom(t));
        }

        public static IEnumerable<Type> FindAllDerivedTypes(this Type type, Assembly assembly, Func<Type, bool> predicate)
        {
            return assembly
                .GetLoadableTypes()
                .Where(t =>
                    t != type &&
                    type.IsAssignableFrom(t))
                .Where(predicate);
        }

        private static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }

        public static Dictionary<string, Type> FindAllServiceToRegisterFrom<TParentServiceInterface>()
        {
            var baseServiceInterfaces = FindAllDerivedTypes<TParentServiceInterface>(t => t.IsInterface);

            var interfaceService = new Dictionary<string, Type>();

            foreach (Type bsInterfaceType in baseServiceInterfaces)
            {
                IEnumerable<Type> bsType = bsInterfaceType.FindAllDerivedTypes(t => !t.IsInterface);
                if (bsType.Count() == 1)
                {
                    interfaceService.Add(bsInterfaceType.Name, bsType.First());
                }
            }

            return interfaceService;
        }
    }
}
