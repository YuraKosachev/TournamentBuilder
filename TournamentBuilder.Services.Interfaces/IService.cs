using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBuilder.Domain.Core;
using TournamentBuilder.Domain.Extensions;

namespace TournamentBuilder.Services.Interfaces
{
    public interface IService<TModel>
        where TModel:class,IModel
    {
        IAppQuery<TModel> OptionsList();
        TModel Set(TModel model);
        TModel Item(TModel model);
        TModel Update(TModel model);
        TModel Delete(TModel model);
        int Save();

    }
}
