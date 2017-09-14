using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBuilder.Domain.Core;
using TournamentBuilder.Domain.Interfaces;

namespace TournamentBuilder.Services.Interfaces
{
    public interface ITeamService:IService<Team>,ILookup
    {
    }
}
