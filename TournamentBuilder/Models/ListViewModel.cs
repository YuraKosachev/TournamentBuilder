using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TournamentBuilder.Models
{
    public class ListViewModel<TModel>
    {
        public IEnumerable<TModel> List { get; set; }
        public int CountItem { get; set; }
    }
}