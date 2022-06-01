// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using MGK.ServiceBase.CQRS.SeedWork;

namespace BSoft.BinanceGraph.API.Models.ProofOfConcept
{
    public class PersonViewModel : IResponse
    {
        public Guid PersonId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string DocumentNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }
    }
}
