using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBuilder.Services.Interfaces
{
    public interface IService<TModel>
        where TModel:class
    {
        IEnumerable<TModel> List();
        TModel Item(TModel model);


    }
}
