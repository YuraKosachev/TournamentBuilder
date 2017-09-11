using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace TournamentBuilder.Domain.Extensions
{
    public interface IAppQuery<TModel> : IEnumerable<TModel>
    {
        IAppQuery<TModel> TakePage(int current, int size);
        IAppQuery<TModel> Sort(string property, bool ascending);
        IAppQuery<TModel> AndAlsoFilter(Expression<Func<TModel, bool>> predicate);
        IAppQuery<TModel> OrAlsoFilter(Expression<Func<TModel, bool>> predicate);
    }
}
