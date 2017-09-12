using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBuilder.Domain.Interfaces;
using TournamentBuilder.Infrastructure.Data.Providers;

namespace TournamentBuilder.Infrastructure.Data
{
    public class ProviderFactory : IProviderFactory
    {
        public IPlayerProvider PlayerProvider => new PlayerProvider();

        public ITeamProvider TeamProvider => new TeamProvider();

        public ITournamentProvider TournamentProvider => new TournamentProvider();
    }
}
