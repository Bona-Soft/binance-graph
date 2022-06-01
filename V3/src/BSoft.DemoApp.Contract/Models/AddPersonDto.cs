// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using BSoft.BApp.Core.Automapper.Interfaces;
using BSoft.DemoApp.Contract.Interfaces.Manager;

namespace BSoft.DemoApp.Manager.Models.ProofOfConcept
{
    public record AddPersonDto
        (string Name,
        string Surname,
        string DocumentNumber,
        DateTime BirthDate)
        : IBaseServiceContract, IBaseMappeable
    {
    }
}
