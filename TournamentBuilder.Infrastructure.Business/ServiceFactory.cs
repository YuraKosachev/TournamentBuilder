using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBuilder.Services.Interfaces;

namespace TournamentBuilder.Infrastructure.Business
{
    public class ServiceFactory : IServiceFactory
    {
        public IPlayerService PlayerService
        {
            get
            {
                return new PlayerService();
            }
        }

        public ITeamService TeamService
        {
            get
            {
                return new TeamService();
            }
        }
    }
}
