using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TournamentBuilder.Domain.Extensions.Options;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBuilder.Domain.Extensions
{
    public class AppQuery<TEntity> : IAppQuery<TEntity>
    {
        private IQueryable<TEntity> _context;
        private PagingOptions _paging;
        private SortingOptions _sorting;
        private FilteringOptions<TEntity> _filtering;

        public AppQuery(IQueryable<TEntity> context)
        {
            _context = context;
        }
        public IAppQuery<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            _filtering = new FilteringOptions<TEntity>(predicate);
            return this;
        }
        public IAppQuery<TEntity> AndAlsoFilter(Expression<Func<TEntity, bool>> predicate)
        {
            if (_filtering == null)
                _filtering = new FilteringOptions<TEntity>(predicate);
            else
                _filtering.And(predicate);

            return this;
        }

        public int CountItem()
        {
            return _paging.Total;
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return _context.Filter(_filtering).Sort(_sorting).TakePage(_paging).GetEnumerator();
        }

        public IAppQuery<TEntity> OrAlsoFilter(Expression<Func<TEntity, bool>> predicate)
        {
            if (_filtering == null)
                _filtering = new FilteringOptions<TEntity>(predicate);
            else
                _filtering.Or(predicate);
            return this;
        }

        public IAppQuery<TEntity> Sort(string property, bool ascending)
        {
            _sorting = new SortingOptions(property, ascending); 

            return this;
        }

        public IAppQuery<TEntity> TakePage(int current, int size)
        {
            _paging = new PagingOptions(current, size);
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
