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
    }
}
