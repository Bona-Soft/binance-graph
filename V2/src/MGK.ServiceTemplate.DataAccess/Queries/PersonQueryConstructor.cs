// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using System.Collections.Generic;
using AutoMapper;
using BSoft.DemoApp.Entities;
using BSoft.DemoApp.DataAccess.Contexts;
using BSoft.DemoApp.DataAccess.Expressions.ProofOfConcept;
using BSoft.DemoApp.DataAccess.Infrastructure.Queries.ProofOfConcept;
using MGK.ServiceBase.DAL.Infrastructure.Queries;

namespace BSoft.DemoApp.DataAccess.Queries.ProofOfConcept
{
    public class PersonQueryConstructor :
        ProofOfConceptQueryConstructor<Person, IPersonQueryConstructor>,
        IPersonQueryConstructor
    {
        public PersonQueryConstructor(Contexts.AppContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public IPersonQueryConstructor FilterByDocumentNumber(string documentNumber)
            => FilterBy(PersonExpressions.DocumentNumberFilter(documentNumber));

        public IPersonQueryConstructor FilterById(Guid personId)
            => FilterBy(PersonExpressions.PersonIdFilter(personId));

        public IPersonQueryConstructor OrderByFullName()
        {
            var keySelectors = new List<OrderSelector<Person, object>>
            {
                new OrderSelector<Person, object> { Key = p => p.Name },
                new OrderSelector<Person, object> { Key = p => p.Surname }
            };

            return OrderByMany(keySelectors);
        }
    }
}
