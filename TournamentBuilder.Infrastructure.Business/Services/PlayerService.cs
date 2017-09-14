using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBuilder.Domain.Interfaces;
using TournamentBuilder.Domain.Extensions;
using System.Data.Entity;
using TournamentBuilder.Infrastructure.Data;
using TournamentBuilder.Domain.Core;
using TournamentBuilder.Services.Interfaces;
using TournamentBuilder.Domain.Exceptions;
using TournamentBuilder.Infrastructure.Data.Providers;

namespace TournamentBuilder.Infrastructure.Business
{
    public class PlayerService: TournamentBuilderService<Player, PlayerProvider>, IPlayerService
    {
        public PlayerService() : base() { }

        public IDictionary<Guid, string> GetDictionary()
        {
            return Provider.GetDictionary();
        }
    }
}
