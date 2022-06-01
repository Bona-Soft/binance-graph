using AutoMapper;
using MGK.ServiceBase.DAL.Infrastructure.Queries;
using MGK.ServiceBase.DAL.SeedWork;
using BSoft.BinanceGraph.DataAccess.Contexts;
using System.Linq.Expressions;
using LinqKit;
using System;

namespace BSoft.BinanceGraph.DataAccess.Infrastructure.Queries.ProofOfConcept
{
	public abstract class BaseQueryBuilder<TEntity, TQueryBuilder> : QueryBuilder<BinanceGraphContext, TEntity, TQueryBuilder>
		where TEntity : class, IDataUnit
		where TQueryBuilder : class, IQueryBuilder
	{
		public BaseQueryBuilder(BinanceGraphContext context, IMapper mapper)
			: base(context, mapper)
		{
		}

		protected Expression<Func<TEntity, bool>> Expression(Expression<Func<TEntity, bool>> exp)
		 => PredicateBuilder.New<TEntity>().And(exp);

		protected Expression<Func<TEnt, bool>> Expression<TEnt>(Expression<Func<TEnt, bool>> exp)
		 => PredicateBuilder.New<TEnt>().And(exp);
	}
}
