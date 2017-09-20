using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBuilder.Domain.Core;
using TournamentBuilder.Infrastructure.Data.Providers;
using TournamentBuilder.Services.Interfaces;


namespace TournamentBuilder.Infrastructure.Business
{
    public class TournamentSettingsService: TournamentBuilderService<TournamentSettings, TournamentSettingsProvider>, ITournamentSettingsService
    {
        public TournamentSettingsService() : base() { }
    }
}
