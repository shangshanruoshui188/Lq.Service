using Lq.Data.Model.Entity;
using System;
using System.Threading.Tasks;

namespace Lq.Store
{
    public interface IStore<TEntity>:IDisposable where TEntity:IEntity
    {
        Task CreateAsync(TEntity entity);
        Task DeteleAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<TEntity> FindByIdAsync(int id);
    }
}
