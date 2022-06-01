// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using System.Collections.Generic;
using BSoft.BApp.Core.Automapper.Extensions;
using BSoft.BApp.Core.Automapper.Infrastructure;
using BSoft.BApp.Core.Automapper.Interfaces;
using BSoft.BApp.Core.Extensions;

namespace BSoft.BApp.Core.Mapper.Infraestructure
{
    public class BaseRegisterMapperProfile : BaseMapperProfile
    {
        public BaseRegisterMapperProfile()
        {
            AddDynamicAutomappings();
        }

        public void AddDynamicAutomappings()
        {
            IEnumerable<Type> classes = TypeExt.FindAllDerivedTypes<IBaseMappeable>();
            IEnumerable<Type> classes2 = TypeExt.FindAllDerivedTypes<IBaseMappeable>();

            foreach (Type obj in classes)
            {
                if (!obj.IsAbstract && !obj.IsInterface)
                {
                    foreach (Type obj2 in classes2)
                    {
                        if (obj != obj2 && !obj2.IsAbstract && !obj2.IsInterface)
                        {
                            CreateMap(obj, obj2)
                               .IgnoreAllNonExisting(obj, obj2);
                        }
                    }
                }
            }
        }
    }
}
