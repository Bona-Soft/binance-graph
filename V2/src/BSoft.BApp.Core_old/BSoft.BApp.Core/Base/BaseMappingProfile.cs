// Copyright (c) Zenfolio, Inc. All rights reserved.

using System;
using System.Collections.Generic;
using AutoMapper;
using BSoft.BApp.Core.Automapper.Extensions;
using BSoft.BApp.Core.Extensions;
using BSoft.BApp.Core.Interfaces;

namespace BSoft.BApp.Core.Automapper.Infrastructure
{
    public abstract class BaseMappingProfile : Profile
    {
        protected BaseMappingProfile()
        {
            AddDynamicAutomappings();
        }

        protected virtual void AddDynamicAutomappings()
        {
            IEnumerable<Type> classes = TypeExt.FindAllDerivedTypes<IMappeable>();
            IEnumerable<Type> classes2 = TypeExt.FindAllDerivedTypes<IMappeable>();

            foreach (Type obj in classes)
            {
                foreach (Type obj2 in classes2)
                {
                    if (obj != obj2)
                    {
                        CreateMap(obj, obj2)
                           .IgnoreAllNonExisting(obj, obj2);
                    }
                }
            }
        }
    }
}
