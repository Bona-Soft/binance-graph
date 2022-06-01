// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using System.Linq.Expressions;
using BSoft.DemoApp.Entities;
using LinqKit;

namespace BSoft.DemoApp.DataAccess.Expressions.ProofOfConcept
{
    public static class PersonExpressions
    {
        public static Expression<Func<Person, bool>> DocumentNumberFilter(string documentNumber)
            => PredicateBuilder.New<Person>().And(p => p.DocumentNumber == documentNumber);

        public static Expression<Func<Person, bool>> PersonIdFilter(Guid personId)
            => PredicateBuilder.New<Person>().And(p => p.Id == personId);
    }
}
