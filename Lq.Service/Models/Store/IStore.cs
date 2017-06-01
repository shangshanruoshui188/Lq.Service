using Lq.Service.Models.Entity;
using System.Threading.Tasks;

namespace Lq.Service.Models.Store
{
    public interface IStore<TEntity> where TEntity:IEntity
    {
        Task<TEntity> GetByIdAsync(int id);

        Task CreateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);
    }
}