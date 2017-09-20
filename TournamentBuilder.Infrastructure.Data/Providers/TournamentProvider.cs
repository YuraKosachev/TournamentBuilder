using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBuilder.Domain.Core;
using TournamentBuilder.Domain.Extensions;
using TournamentBuilder.Domain.Interfaces;
using TournamentBuilder.Domain.Exceptions;

namespace TournamentBuilder.Infrastructure.Data.Providers
{
    public class TournamentProvider:TournamentBuilderProvider<Tournament>,ITournamentProvider
    {
        public TournamentProvider() : base() { }
  

        public IParticipant SetParticipant(Tournament tournament,IParticipant model,bool isTeam)
        {
            var tourn = Context.Set<Tournament>().Find(tournament.Id);
            if(isTeam )

            if (isTeam)
                tourn.Teams.Add(Context.Set<Team>().Find((model as Team).Id));
            else
                tourn.Players.Add(Context.Set<Player>().Find((model as Player).Id));


            return model;
        }
    }
}
