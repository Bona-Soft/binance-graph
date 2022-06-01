using AutoMapper;
using MGK.ServiceBase.DAL.Infrastructure.Queries;
using MGK.ServiceBase.DAL.SeedWork;
using BSoft.BinanceGraph.DataAccess.Contexts;
using System.Linq.Expressions;
using LinqKit;
using System;

namespace BSoft.BinanceGraph.DataAccess.Infrastructure.Queries.ProofOfConcept
{
	public abstract class BaseQueryBuilder<TEntity, TKey, TQueryBuilder> : BaseQueryBuilder<TEntity, TQueryBuilder>
		where TEntity : class, IDataUnit<TKey>
		where TQueryBuilder : class, IQueryBuilder
	{
		public BaseQueryBuilder(BinanceGraphContext context, IMapper mapper)
			: base(context, mapper)
		{
		}

		public TQueryBuilder FilterById(TKey Id)
			=> FilterBy(Expression(x => x.Id.Equals(Id)));

	}
}
