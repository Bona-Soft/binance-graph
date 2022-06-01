// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using BSoft.BApp.Core.Automapper.Interfaces;
using MGK.ServiceBase.DAL.Infrastructure.DataUnits;

namespace BSoft.DemoApp.Entities
{
    public class Person : AuditableDataUnit<Guid>, IBaseMappeable
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string DocumentNumber { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
