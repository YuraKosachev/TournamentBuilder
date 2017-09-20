using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TournamentBuilder.Domain.Core;
using TournamentBuilder.Domain.Interfaces;
using TournamentBuilder.Domain.Extensions;
using TournamentBuilder.Domain.Exceptions;

namespace TournamentBuilder.Infrastructure.Data.Providers
{
    public class TournamentSettingsProvider:TournamentBuilderProvider<TournamentSettings>,ITournamentSettingsProvider
    {
        public TournamentSettingsProvider() : base() { }

        public override TournamentSettings Set(TournamentSettings model)
        {
            Context.Set<TournamentSettings>().Add(model);
            return model;
        }

    }
}
