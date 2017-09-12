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

namespace TournamentBuilder.Infrastructure.Business
{
    public abstract class TournamentBuilderService<TModel,TProvider>:IService<TModel>
        where TModel:class,IModel
        where TProvider: class,IRepository<TModel>,new()
    {
        public TProvider Provider { get; private set; }
        public TournamentBuilderService(TProvider provider)
        {
            Provider = provider;
        }
        public TournamentBuilderService() : this(new TProvider()) { }

        public virtual IAppQuery<TModel> OptionsList()
        {
            return Provider.OptionsList();
        }

        public virtual TModel Set(TModel model)
        {
            var item = Provider.Set(model);
            Provider.Save();
            return item;
        }

        public virtual TModel Item(TModel model)
        {
            return Provider.Item(model);
        }

        public virtual TModel Update(TModel model)
        {
            var item = Provider.Update(model);
            Provider.Save();
            return item;
        }

        public virtual TModel Delete(TModel model)
        {
            var item = Provider.Delete(model);
            Provider.Save();
            return item;
        }

       
        //public IProviderFactory Providers { get; private set; }
        //public TournamentBuilderService(IProviderFactory providers)
        //{
        //    Providers = providers;
        //}
        //public TournamentBuilderService() : this(new ProviderFactory()) { }
    }
}
