using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBuilder.Domain.Extensions.Options
{
    public class PagingOptions
    {
        private int _current;
        private int _size;
        public int Total { get; private set; }
        public PagingOptions(int current, int size)
        {
            _current = current;
            _size = size;
        }
        public IQueryable<TEntity> TakePage<TEntity>(IQueryable<TEntity> source)
        {
            Total = source.Count();
            return source.Skip((_current - 1) * _size).Take(_size);
        }
    }
}
