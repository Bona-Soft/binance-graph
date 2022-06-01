// Copyright (c) BonaSoft, Inc. All rights reserved.

using BSoft.BApp.Core.Automapper.Interfaces;
using BSoft.BApp.Core.Controller;

namespace BSoft.BApp.Core.Infraestructure
{
    public abstract record BaseDto : BaseObjectDto, IBaseMappeable
    {
    }
}
