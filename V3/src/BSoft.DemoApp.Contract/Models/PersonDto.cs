// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using BSoft.BApp.Core.Infraestructure;
using BSoft.DemoApp.Contract.Interfaces.Manager;

namespace BSoft.DemoApp.Manager.Models.ProofOfConcept
{
    public record PersonDto

        (string Name,

        string Surname,

        string DocumentNumber,

        DateTime BirthDate,

        DateTime CreationDate,

        DateTime? LastUpdateDate)
        : BaseDto, IBaseServiceResponse
    {
        public string FullName => $"{Name} {Surname}";
        public Guid PersonId { get; set; }
    }
}
