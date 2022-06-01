// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using BSoft.BApp.Core.Automapper.Interfaces;

namespace BSoft.DemoApp.Contract.ParamsDto
{
    public class BinanceApiDto : IBaseMappeable
    {
        public Guid? Id { get; set; }
        public string ApiKey { get; set; }
        public string SecretKey { get; set; }
    }
}
