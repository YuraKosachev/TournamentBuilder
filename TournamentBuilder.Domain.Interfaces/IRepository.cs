using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBuilder.Domain.Extensions;

namespace TournamentBuilder.Domain.Interfaces
{
    public interface IRepository<TEntity>:IDisposable
    {
        IAppQuery<TEntity> OptionsList();
        TEntity Set(TEntity model);
        TEntity Item(TEntity model);
        TEntity Update(TEntity model);
        TEntity Delete(TEntity model);
        int Save();
    }
}
