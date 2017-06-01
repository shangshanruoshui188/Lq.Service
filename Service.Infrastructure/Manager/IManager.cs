using Service.Entity;
using System;
using System.Threading.Tasks;

namespace Service.Manager
{
    /// <summary>
    /// 所有业务逻辑对象必须实现的接口。Manager接口是对Store接口的组合，
    /// 以实现更为复杂的业务逻辑，并以DI的形式注入到Controller中。
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IManager<TEntity>:IDisposable where TEntity : IEntity
    {
        Task CreateAsync(TEntity entity);
        Task DeteleAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<TEntity> FindByIdAsync(int id);
    }
}
