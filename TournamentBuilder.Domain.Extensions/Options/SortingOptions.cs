using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBuilder.Domain.Extensions.Options
{
    public class SortingOptions
    {
        public string Property { get; set; }
        public bool Ascending { get; set; }
        public SortingOptions(string propert)
        {

        }
        public IQueryable<TEntity> Sort<TEntity>(IQueryable<TEntity> source)
        {
            return source.OrderBy<TModel>();//Sort.OrderBy(String.Format("{0} {1}", Property, Ascending ? "ASC" : "DESC"));
        }

    }
}
