// Copyright (c) BonaSoft, Inc. All rights reserved.

using MGK.ServiceBase.CQRS.SeedWork;

namespace BSoft.BinanceGraph.API.Models.ProofOfConcept
{
    public class RemovedPersonViewModel : IResponse
    {
        public string Fullname { get; }

        public string DocumentNumber { get; }

        public RemovedPersonViewModel(string fullName, string documentNumber)
        {
            Fullname = fullName;
            DocumentNumber = documentNumber;
        }
    }
}
