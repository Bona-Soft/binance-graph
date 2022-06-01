// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using BSoft.BApp.Core.DataAccess;
using BSoft.BApp.Core.DataAccess.Interfaces;
using BSoft.DemoApp.Entities;
using MGK.ServiceBase.DAL.SeedWork;

namespace BSoft.DemoApp.DataAccess.Infrastructure.Queries.ProofOfConcept
{
    public interface IPersonQueryConstructor : IQueryConstructor<Person, IPersonQueryConstructor>, IBaseDataAccessService
    {
        IPersonQueryConstructor FilterByDocumentNumber(string documentNumber);

        IPersonQueryConstructor FilterById(Guid personId);

        IPersonQueryConstructor OrderByFullName();
    }
}
