using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBuilder.Services.Interfaces;
using TournamentBuilder.Domain.Core;
using TournamentBuilder.Infrastructure.Data.Providers;

namespace TournamentBuilder.Infrastructure.Business
{
    public class TournamentService: TournamentBuilderService<Tournament, TournamentProvider>,ITournamentService
    {
        public TournamentService() : base(){ }

        public IParticipant SetParticipant(Tournament tournament, IParticipant model, bool isTeam)
        {
            var item = Provider.SetParticipant(tournament,model, isTeam);
            Provider.Save();

            return item;
        }
    }
}
