using GerenciadorFC.Crawler.Dominios.Prefeituras.Interfaces.Repositorios;
using GerenciadorFC.Crawler.Prefeituras.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFC.Crawler.Prefeituras.Data.Repositorios
{
    public class RepositoryBase<TEntity> : IDisposable,
       IRepositoryBase<TEntity> where TEntity : class
    {

        public RepositoryBase(PrefeiturasContexto contexto)
        {
            context = contexto;
        }
        private readonly PrefeiturasContexto context;

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
