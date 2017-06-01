using Service.Entity;
using Service.Store;
using System.Threading.Tasks;

namespace Service.Manager
{
    /// <summary>
    /// 业务逻辑对象需要继承的基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class BaseManager<TEntity> : IManager<TEntity>
        where TEntity : IEntity
    {
        protected bool disposed;
        protected readonly IStore<TEntity> store;

        public BaseManager(IStore<TEntity> store)
        {
            this.store = store;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await store.CreateAsync(entity);
        }

        public async Task DeteleAsync(TEntity entity)
        {
            await store.DeteleAsync(entity);
        }

        public void Dispose()
        {
            if (!disposed)
            {
                store.Dispose();
                disposed = true;
            }
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await store.FindByIdAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await store.UpdateAsync(entity);
        }



    }




}
