using Lq.Data.Model.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Lq.Store
{
    public interface IEntityStore<TEntity> where TEntity:IEntity
    {
        IQueryable<TEntity> EntitySet { get; }

        Task<TEntity> FindByIdAsync(int id);

        void Create(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);
    }
}