using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBuilder.Services.Interfaces
{
    public interface IServiceFactory
    {
        ITeamService TeamService { get; }
        IPlayerService PlayerService { get; }
    }
}
