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

        public IDictionary<Guid, string> GetDictionary()
        {
            return Context.Set<Player>().ToDictionary<Player, Guid, string>(key => key.Id, value => value.NickName);
        }
    }
}
