using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBuilder.Domain.Extensions.Options
{
    public class SortingOptions
    {
        public string Property { get; set; }
        public string Ascending { get; set; }

        public SortingOptions(string property,bool ascending)
        {
            Property = property;
            Ascending = ascending ? "ASC" : "DESC";
        }
        public IQueryable<TEntity> Sort<TEntity>(IQueryable<TEntity> source)
        {
            return source.OrderBy<TEntity>($"{Property} {Ascending}");
        }
    }
}
