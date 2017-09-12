using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBuilder.Domain.Extensions.Options
{
    public class FilteringOptions<TModel>
    {
        public Expression<Func<TModel, bool>> Predicate { get; private set; }
        public FilteringOptions(Expression<Func<TModel, bool>> predicate)
        {
            Predicate = predicate;
        }
        
        public FilteringOptions<TModel> And(Expression<Func<TModel, bool>> predicate)
        {
            Predicate = Predicate.AndAlso(predicate);

            return this;
        }
        public FilteringOptions<TModel> Or(Expression<Func<TModel, bool>> predicate)
        {
            Predicate = Predicate.OrElse(predicate);

            return this;
        }
        public IQueryable<TModel> Filter(IQueryable<TModel> context)
        {
            return context.Where(Predicate);
        }
    }
}
