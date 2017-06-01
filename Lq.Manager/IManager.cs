using Lq.Data.Model.Entity;
using System.Threading.Tasks;

namespace Lq.Manager
{
    public interface IManager<TEntity> where TEntity : IEntity
    {
        Task CreateAsync(TEntity entity);
        Task DeteleAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<TEntity> FindByIdAsync(int id);
    }
}
