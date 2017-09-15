using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TournamentBuilder.Domain.Core;
using TournamentBuilder.Domain.Interfaces;
using TournamentBuilder.Domain.Extensions;
using TournamentBuilder.Domain.Exceptions;

namespace TournamentBuilder.Infrastructure.Data.Providers
{
    public class TeamProvider:TournamentBuilderProvider<Team>,ITeamProvider
    {
        public TeamProvider() : base() { }
        public override IAppQuery<Team> OptionsList()
        {
            return new AppQuery<Team>(Context.Set<Team>().Include("Players"));
        }
        public override Team Delete(Team model)
        {

            var item = Context.Set<Team>().Include("Players").FirstOrDefault(t => t.Id == model.Id);
            if (item == null)
                throw new ItemNotFoundException("Искомый элемент не найден");
            Context.Set<Team>().Remove(item);
            return item;
        }
        public IDictionary<Guid, string> GetDictionary()
        {
            return Context.Set<Team>().ToDictionary<Team,Guid, string>(key => key.Id, value => value.Name);
        }
    }
}
