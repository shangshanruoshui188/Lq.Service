using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Data.Entity;
using System.Reflection;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using Lq.Service.Models.Entity;
using Lq.Service.Models;
using Lq.Service.Models.Query;

namespace Lq.Service.Controllers
{
    /// <summary>
    /// 整个服务框架的唯一控制器，在进行路由匹配时，会通过路径中的controller名称进行
    /// 泛型实例化。
    /// </summary>
    /// <typeparam name="T">控制器中的实体类型</typeparam>
    [Authorize]
    public class GenericController<T> : ApiController where T:BaseEntity
    {
        private readonly ApplicationDbContext db = ApplicationDbContext.Create();

        private DbSet<T> dbSet;
        private DbSet<T> DbSet
        {
            get
            {
                if (dbSet == null)
                    dbSet = db.Set<T>();
                return dbSet;
            }
        }

        /// <summary>
        /// 自定义查询，请求示例
        /// <code> 
        /// var query = {
        ///    type: "get",
        ///    url: "api/manager/query",
        ///    data:{'[Like]Sex':'m'}
        /// };
        /// </code>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<T> Query(QueryModel model)
        {
            
            return DbSet.Where(model);
        }

        /// <summary>
        /// List
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> Get()
        {
            return DbSet;
        }


        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get(int id)
        {
            T entity = await DbSet.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }


        /// <summary>
        /// 创建新的实体，请求示例
        /// <code> 
        /// var query = {
        ///    type: "post",
        ///    url: "api/manager/post",
        ///    data:{'Sex':'m'}
        /// };
        /// </code> 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Post(T model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DbSet.Add(model);
            await db.SaveChangesAsync();
            return StatusCode(System.Net.HttpStatusCode.Created);
        }


        /// <summary>
        /// 更新实体，请求示例
        /// <code> 
        /// var query = {
        ///    type: "put",
        ///    url: "api/manager/put/1",
        ///    data:{'id':'1','[Like]Sex':'m'}
        /// };
        /// </code>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Put(int id, T model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.Id)
            {
                return BadRequest();
            }
            db.Entry(model).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await Exists(DbSet, id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        /// <summary>
        /// 删除实体，请求示例
        /// <code> 
        /// var query = {
        ///    type: "delete",
        ///    url: "api/manager/delete/1"
        /// };
        /// </code>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Delete(int id)
        {
            T model =await DbSet.FindAsync(id);
            if (model == null)
                return NotFound();
            DbSet.Remove(model);
            await db.SaveChangesAsync();

            return Ok(model);

        }


        

        private async Task<bool> Exists(DbSet<T> set,int id)
        {
            return (await set.CountAsync(e => e.Id == id)) >0;
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
    }
}
