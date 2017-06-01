using Lq.Data.Model.Entity;
using Lq.Store;
using System;
using System.Threading.Tasks;

namespace Lq.Manager
{
    public abstract class BaseManager<TEntity> : IManager<TEntity>,IDisposable 
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
