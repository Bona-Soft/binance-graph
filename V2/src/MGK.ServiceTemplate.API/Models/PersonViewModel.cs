// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using BSoft.BApp.Core.Automapper.Interfaces;
using BSoft.DemoApp.API.Infrastructure.Contracts.ProofOfConcept;
using MGK.ServiceBase.CQRS.SeedWork;

namespace BSoft.DemoApp.API.Models.ProofOfConcept
{
    public record PersonViewModel
        (Guid PersonId,
        string Name,
        string Surname,
        string DocumentNumber,
        DateTime BirthDate,
        DateTime CreationDate,
        DateTime? LastUpdateDate)
        : IPersonContract, IResponse, IBaseMappeable
    {
    }
}
