using GerenciadorFC.Contextos.Nucleo.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GerenciadorFC.Contextos.Nucleo.Infra.Data
{
    public class RepositoryBase<TEntity, TContext> : IDisposable,
          IRepositoryBase<TEntity> where TEntity : class
          where TContext : DbContext
    {

        public RepositoryBase(TContext contexto)
        {
            context = contexto;
        }
        private readonly TContext context;

        public IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public TEntity Find(params object[] key)
        {
            return context.Set<TEntity>().Find(key);
        }

        public void Update(TEntity obj)
        {
            context.Entry(obj).State = EntityState.Modified;
        }

        public void SaveAll()
        {
            context.SaveChanges();
        }

        public void Add(TEntity obj)
        {
            context.Set<TEntity>().Add(obj);
        }

        public void Delete(Func<TEntity, bool> predicate)
        {
            context.Set<TEntity>()
                .Where(predicate).ToList()
                .ForEach(del => context.Set<TEntity>().Remove(del));
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
