using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBuilder.Domain.Interfaces;
using TournamentBuilder.Domain.Core;

namespace TournamentBuilder.Infrastructure.Data.Providers
{
    public class PlayerProvider:TournamentBuilderProvider<Player>,IPlayerProvider
    {
        public PlayerProvider() : base() { }
    }
}
