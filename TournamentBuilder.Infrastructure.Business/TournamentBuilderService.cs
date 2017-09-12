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
using TournamentBuilder.Domain.Exceptions;

namespace TournamentBuilder.Infrastructure.Business
{
    public abstract class TournamentBuilderService<TModel>
        where TModel:class,IModel
    {
        public IProviderFactory Providers { get; private set; }
        public TournamentBuilderService(IProviderFactory providers)
        {
            Providers = providers;
        }
        public TournamentBuilderService() : this(new ProviderFactory()) { }
    }
}
