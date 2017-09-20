using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBuilder.Domain.Core;

namespace TournamentBuilder.Services.Interfaces
{
    public interface ITournamentService:IService<Tournament>
    {
        IParticipant SetParticipant(Tournament tournament, IParticipant model, bool isTeam);
    }
}
