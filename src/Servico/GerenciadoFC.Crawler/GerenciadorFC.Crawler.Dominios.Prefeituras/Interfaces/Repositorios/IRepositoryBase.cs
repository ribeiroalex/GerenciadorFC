using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFC.Crawler.Dominios.Prefeituras.Interfaces.Repositorios
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Get(Func<TEntity, bool> predicate);
        TEntity Find(params object[] key);
        void Update(TEntity obj);
        void SaveAll();
        void Add(TEntity obj);
        void Delete(Func<TEntity, bool> predicate);
    }
}
