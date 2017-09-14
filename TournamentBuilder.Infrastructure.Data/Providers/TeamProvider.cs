using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBuilder.Domain.Core;
using TournamentBuilder.Domain.Interfaces;
using TournamentBuilder.Domain.Extensions;

namespace TournamentBuilder.Infrastructure.Data.Providers
{
    public class TeamProvider:TournamentBuilderProvider<Team>,ITeamProvider
    {
        public TeamProvider() : base() { }
        public override IAppQuery<Team> OptionsList()
        {
            return new AppQuery<Team>(Context.Set<Team>().Include("Players"));
        }

        public IDictionary<Guid, string> GetDictionary()
        {
            return Context.Set<Team>().ToDictionary<Team,Guid, string>(key => key.Id, value => value.Name);
        }
    }
}
