// Copyright (c) BonaSoft, Inc. All rights reserved.

using AutoMapper;
using BSoft.DemoApp.DataAccess.Contexts;
using MGK.ServiceBase.DAL.Infrastructure.Queries;
using MGK.ServiceBase.DAL.SeedWork;

namespace BSoft.DemoApp.DataAccess.Infrastructure.Queries.ProofOfConcept
{
    public abstract class ProofOfConceptQueryConstructor<TEntity, TQueryConstructor> :
        QueryConstructor<AppContext, TEntity, TQueryConstructor>
        where TEntity : class, IDataUnit
        where TQueryConstructor : class, IQueryConstructor
    {
        protected ProofOfConceptQueryConstructor(AppContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
