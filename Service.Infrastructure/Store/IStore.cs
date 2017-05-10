using Service.Entity;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace Service.Store
{
    /// <summary>
    /// 所有实体类型的DAO(Data Access Object)对象必须实现的接口，是对实体操作的整体抽象。
    /// Store对象通过DI注入到Manager中去，因此每个Store必须实现Dispose方法，
    /// 以达到及时释放资源的目的。
    /// </summary>
    /// <typeparam name="TEntity">具体的实体类型，需要实现IEntity接口，即拥有int类型的主键</typeparam>
    public interface IStore<TEntity> : IDisposable where TEntity : IEntity
    {
        /// <summary>
        /// 以异步的方式创建一个实体对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task CreateAsync(TEntity entity);
        /// <summary>
        /// 以异步的方式删除一个实体对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeteleAsync(TEntity entity);

        /// <summary>
        /// 以异步的方式更新一个实体对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// 以异步的方式按照id查找一个实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> FindByIdAsync(int id);

        /// <summary>
        /// 获取实体指定名称的属性值，该属性应该是一对一的单属性值
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="entity"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        Task<TProperty> GetProperty<TProperty>(TEntity entity, string propertyName);

        /// <summary>
        /// 设置实体的属性值，该属性应该是一对一的属性
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="entity"></param>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        /// <returns></returns>
        Task SetProperty<TProperty>(TEntity entity, string propertyName, TProperty propertyValue);


        /// <summary>
        /// 通过属性值查找实体，该属性应该是一对一的属性
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        /// <returns></returns>
        Task<TEntity> FindByProperty<TProperty>(string propertyName, TProperty propertyValue)
    }
}
