using Service.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Store
{
    internal interface IEntityStore<TEntity> where TEntity:IEntity
    {
        IQueryable<TEntity> EntitySet { get; }

        Task<TEntity> FindByIdAsync(int id);

        void Create(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);
    }
}