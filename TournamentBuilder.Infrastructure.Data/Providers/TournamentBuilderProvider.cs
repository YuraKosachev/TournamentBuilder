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

namespace TournamentBuilder.Infrastructure.Data.Providers
{
    public class TournamentBuilderProvider<TEntity>:IRepository<TEntity>
        where TEntity:class,IModel
    {
        public DbContext Context { get; private set; }
        public TournamentBuilderProvider(DbContext context)
        {
            Context = context;
        }
        public TournamentBuilderProvider() : this(TournamentBuilderDbContext.Instance()) { }

        public virtual IAppQuery<TEntity> OptionsList()
        {
            return new AppQuery<TEntity>(Context.Set<TEntity>().AsNoTracking());
        }

        public virtual TEntity Item(TEntity model)
        {
            var item = Context.Set<TEntity>().Find(model.Id);
            if (item == null)
                throw new ItemNotFoundException("Искомый элемент не найден");
            return item;
        }

        public virtual TEntity Update(TEntity model)
        {
            Context.Entry<TEntity>(model).State = EntityState.Modified;
            return model;
        }

        public virtual TEntity Delete(TEntity model)
        {
            var item = Context.Set<TEntity>().Find(model.Id);
            if (item == null)
                throw new ItemNotFoundException("Искомый элемент не найден");
            Context.Set<TEntity>().Remove(item);
            return item;
        }
        public virtual TEntity Set(TEntity model)
        {
            model.Id = Guid.NewGuid();
           
            Context.Set<TEntity>().Add(model);
            return model;
        }

        public int Save()
        {
            return Context.SaveChanges();
        }

        //disposing 
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

       
    }
}
