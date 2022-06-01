using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BSoft.BApp.Core.Extensions
{
    public static class TypeExt
    {
        public static IEnumerable<Type> FindAllDerivedTypes<T>()
        {
            return FindAllDerivedTypes<T>(Assembly.GetAssembly(typeof(T)));
        }

        public static IEnumerable<Type> FindAllDerivedTypes<T>(Assembly assembly)
        {
            Type derivedType = typeof(T);
            return assembly
                .GetTypes()
                .Where(t =>
                    t != derivedType &&
                    derivedType.IsAssignableFrom(t)
                    );
        }
    }
}
