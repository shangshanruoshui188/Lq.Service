using Service.Entity;
using Service.Exception;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Service.Store
{
    public abstract class BaseStore<TEntity> : IStore<TEntity> where TEntity : BaseEntity
    {
        public IDbContext Context { get; protected set; }
        internal IEntityStore<TEntity> store;
        protected bool disposed;
        public bool AutoSaveChanges { get; set; }

        /// <summary>
        /// 构造方法，必须传入一个DbContext对象
        /// </summary>
        /// <param name="context">DbContext对象</param>
        public BaseStore(IDbContext context)
        {
            Context = context;
            AutoSaveChanges = true;
            store = new EntityStore<TEntity>(Context);
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            store.Create(entity);
            entity.CreateDate = DateTime.Now;
            await SaveChanges();
        }

        public virtual async Task DeteleAsync(TEntity entity)
        {
            store.Delete(entity);
            await SaveChanges();
        }

        public virtual async Task<TEntity> FindByIdAsync(int id)
        {
            return await store.FindByIdAsync(id);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            store.Update(entity);
            entity.UpdateDate = DateTime.Now;
            await SaveChanges();
        }

        private async Task SaveChanges()
        {
            if (AutoSaveChanges)
            {
                await Context.SaveChangesAsync();
            }
        }

        #region 多对多关系的处理
        /// <summary>
        /// 以异步的方法获取和<typeparamref name="TEntity"/>具有多对多关系的属于<paramref name="entity"/>的<typeparamref name="TTarget"/>类型的对象，
        /// 需要指定<typeparamref name="TEntity"/>和<typeparamref name="TTarget"/>的中间映射类以进行join查询。
        /// </summary>
        /// <typeparam name="TMap">多对多中间映射类型</typeparam>
        /// <typeparam name="TTarget">多对多目标类型</typeparam>
        /// <param name="entity">需要进行查询的对象</param>
        /// <param name="mapKey">返回<typeparamref name="TMap"/>类型的和<typeparamref name="TEntity"/>进行关联的外键的委托</param>
        /// <param name="targetKey">返回<typeparamref name="TMap"/>类型的和<typeparamref name="TTarget"/>进行关联的外键的委托</param>
        /// <returns>属于<paramref name="entity"/>的<typeparamref name="TTarget"/>类型的对象</returns>
        protected virtual async Task<IList<TTarget>> GetTargetsAsync<TMap, TTarget>(TEntity entity, Func<TMap, int> mapKey, Func<TMap, int> targetKey)
            where TTarget : BaseEntity
            where TMap : class
        {
            var query = from map in Context.Set<TMap>()
                        where mapKey(map) == entity.Id
                        join target in Context.Set<TTarget>() on targetKey(map) equals target.Id
                        select target;
            return await query.ToListAsync();
        }


        /// <summary>
        /// 以异步的方法获取和<typeparamref name="TEntity"/>具有多对多关系的属于<paramref name="entity"/>的<typeparamref name="TTarget"/>类型的对象，
        /// 以及和这些对象关联的<typeparamref name="TMap"/>类型的对象，即获得多对多关系所有的信息。
        /// 需要指定<typeparamref name="TEntity"/>和<typeparamref name="TTarget"/>的中间映射类以进行join查询。
        /// </summary>
        /// <typeparam name="TMap">多对多中间映射类型</typeparam>
        /// <typeparam name="TTarget">多对多目标类型</typeparam>
        /// <param name="entity">需要进行查询的对象</param>
        /// <param name="mapKey">返回<typeparamref name="TMap"/>类型的和<typeparamref name="TEntity"/>进行关联的外键的委托</param>
        /// <param name="targetKey">返回<typeparamref name="TMap"/>类型的和<typeparamref name="TTarget"/>进行关联的外键的委托</param>
        /// <returns>属于<paramref name="entity"/>的<typeparamref name="TTarget"/>类型的对象</returns>
        protected virtual async Task<IDictionary<TMap,TTarget>> GetTargetDetailsAsync<TMap, TTarget>(TEntity entity, Func<TMap, int> mapKey, Func<TMap, int> targetKey)
            where TTarget : BaseEntity
            where TMap : class
        {
            var query = from map in Context.Set<TMap>()
                        where mapKey(map) == entity.Id
                        join target in Context.Set<TTarget>() on targetKey(map) equals target.Id
                        select new { Target = target, Map = map };
            return await query.ToDictionaryAsync(q=>q.Map,q=>q.Target);
        }


        /// <summary>
        /// 以异步的方式向<paramref name="entity"/>对象添加具有多对多关系的<typeparamref name="TTarget"/>类型的对象。
        /// </summary>
        /// <typeparam name="TMap">多对多中间映射类型</typeparam>
        /// <typeparam name="TTarget">多对多目标类型</typeparam>
        /// <param name="entity">要进行添加对象的实体对象</param>
        /// <param name="filter">返回要添加的对象的过滤器委托</param>
        /// <param name="map">根据<paramref name="entity"/>和得到的<typeparamref name="TTarget"/>类型对象生成中间映射对象的委托</param>
        /// <returns></returns>
        protected virtual async Task AddTargetAsync<TMap,TTarget>(TEntity entity, Expression<Func<TTarget, bool>> filter, Func<TEntity, TTarget, TMap> map)
            where TTarget:BaseEntity
            where TMap:class
        {
            TTarget target =await Context.Set<TTarget>().FirstOrDefaultAsync(filter);
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            var m = map(entity, target);
            Context.Set<TMap>().Add(m);
        }

        /// <summary>
        /// 以异步的方式删除多对多关系
        /// </summary>
        /// <typeparam name="TMap">多对多中间映射类型</typeparam>
        /// <typeparam name="TTarget">多对多目标类型</typeparam>
        /// <param name="entity">多对多关系的主实体</param>
        /// <param name="filter">产生多对多关系从实体的过滤器委托</param>
        /// <param name="entityKey">返回中间映射实体和主实体主键进行关联的外键的委托</param>
        /// <param name="targetKey">返回中间映射实体和从实体主键进行关联的外键的委托</param>
        /// <returns></returns>
        protected virtual async Task RemoveTargetAsync<TMap,TTarget>(TEntity entity, Expression<Func<TTarget, bool>> filter, Func<TMap,int>entityKey,Func<TMap,int>targetKey)
            where TTarget : BaseEntity
            where TMap : class
        {
            TTarget target = await Context.Set<TTarget>().FirstOrDefaultAsync(filter);
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            var map =await Context.Set<TMap>().FirstOrDefaultAsync(m => entityKey(m) == entity.Id && targetKey(m) == target.Id);
            Context.Set<TMap>().Remove(map);
        }

        #endregion


        #region 一对多关系的处理

        protected virtual async Task<IList<TMap>> GetMapsAsync<TMap>(TEntity entity, Func<TMap, int> mapKey, Func<TEntity, ICollection<TMap>> property)
            where TMap : class
        {
            await EnsureNavigationPropertyLoaded(entity, mapKey, e=>property(e));
            
            return property(entity).ToList();
        }

        protected virtual Task AddMapAsync<TMap>(TEntity entity, TMap map,Action<int,TMap>foreignKey)
           where TMap : class
        {
            CheckNull(entity,nameof(entity));

            foreignKey(entity.Id,map);
            Context.Set<TMap>().Add(map);

            return Task.FromResult(0);
        }

        protected virtual Task RemoveMapAsync<TMap>(TEntity entity, Func<TMap,bool>filter, Func<TEntity, ICollection<TMap>> property=null)
           where TMap : class
        {
            CheckNull(entity,nameof(entity));

            IEnumerable<TMap> maps;
            IDbSet<TMap> dbSet=Context.Set<TMap>();

            if(property!=null && AreNavigationPropertyLoaded(entity, e => property(e)))
            {
                maps = property(entity).Where(filter);
            }
            else
            {
                maps = dbSet.Where(filter);
            }

            foreach (TMap map in maps)
                dbSet.Remove(map);

            return Task.FromResult(0);
        }


        /// <summary>
        /// 异步加载一对多关系的导航属性至内存
        /// </summary>
        /// <typeparam name="TProperty">导航属性类型</typeparam>
        /// <param name="entity">要加载导航属性的对象</param>
        /// <param name="foreignKey">返回导航属性外键值的委托</param>
        /// <param name="property">返回导航属性集的委托</param>
        /// <returns></returns>
        protected virtual async Task EnsureNavigationPropertyLoaded<TProperty>(TEntity entity, Func<TProperty, int> foreignKey, Expression<Func<TEntity, ICollection<TProperty>>> property)
            where TProperty : class
        {
            CheckNull(entity, nameof(entity));
            if (!AreNavigationPropertyLoaded(entity, property))
            {
                int id = entity.Id;
                await Context.Set<TProperty>().Where(t => foreignKey(t) == id).LoadAsync();
                Context.Entry(entity).Collection(property).IsLoaded = true;
            }
        }

        protected bool AreNavigationPropertyLoaded<TProperty>(TEntity entity, Expression<Func<TEntity, ICollection<TProperty>>> property)
            where TProperty : class
        {
            return Context.Entry(entity).Collection(property).IsLoaded;
        }


        #endregion


        #region 一对一关系的处理
        /// <summary>
        /// 获取实体指定名称的属性值
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="entity"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public Task<TProperty> GetProperty<TProperty>(TEntity entity, string propertyName)
        {
            CheckNull(entity, nameof(entity));
            CheckNull(propertyName, nameof(propertyName));

            var info = GetProperty(propertyName);
            TProperty value = (TProperty)info.GetValue(entity);
            if (value == null)
                value = default(TProperty);
            return Task.FromResult(value);

        }

        /// <summary>
        /// 设置实体指定名称属性的值
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="entity"></param>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        /// <returns></returns>
        public Task SetProperty<TProperty>(TEntity entity, string propertyName, TProperty propertyValue)
        {
            CheckNull(entity, nameof(entity));
            CheckNull(propertyName, nameof(propertyName));

            var info = GetProperty(propertyName);

            info.SetValue(entity, propertyValue);
            return Task.FromResult(0);
        }


        /// <summary>
        /// 根据指定的属性名和属性值过滤实体
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        /// <returns></returns>
        public Task<TEntity> FindByProperty<TProperty>(string propertyName, TProperty propertyValue)
        {
            CheckNull(propertyValue, nameof(propertyValue));
            CheckNull(propertyName, nameof(propertyName));

            var info = GetProperty(propertyName);

            return GetAggregateAsync(entity =>propertyValue.Equals(info.GetValue(entity)));
            
            
        }

        #endregion





        /// <summary>
        /// 根据过滤条件返回唯一实体
        /// </summary>
        /// <param name="filter">过滤器委托</param>
        /// <returns></returns>
        protected virtual async Task<TEntity> GetAggregateAsync(Expression<Func<TEntity, bool>> filter)
        {
            int id;
            TEntity entity;
            if (FindByIdFilterParser.TryMatchAndGetId(filter, out id))
            {
                entity = await Context.Set<TEntity>().FindAsync(id);
            }
            else
            {
                entity = await Context.Set<TEntity>().FirstOrDefaultAsync(filter);
            }

            return entity;
        }

        public virtual void Dispose()
        {
            if (!disposed)
            {
                Context.Dispose();
                disposed = true;
            }
        }

        protected PropertyInfo GetProperty(string propertyName)
        {
            Type type = typeof(TEntity);

            var info = type.GetProperties().Where(p => p.Name.ToLower().Equals(propertyName.ToLower())).FirstOrDefault();
            if (info == null)
                throw new HasNoPropertyException(type.FullName, propertyName);
            return info;
        }

        protected void CheckNull(object obj, string name)
        {
            if (obj == null)
                throw new ArgumentNullException(name);
        }

        private static class FindByIdFilterParser
        {
            // expression pattern we need to match
            private static readonly Expression<Func<TEntity, bool>> Predicate = u => u.Id.Equals(default(int));
            // method we need to match: Object.Equals() 
            private static readonly MethodInfo EqualsMethodInfo = ((MethodCallExpression)Predicate.Body).Method;
            // property access we need to match: User.Id 
            private static readonly MemberInfo UserIdMemberInfo = ((MemberExpression)((MethodCallExpression)Predicate.Body).Object).Member;

            internal static bool TryMatchAndGetId(Expression<Func<TEntity, bool>> filter, out int id)
            {
                // default value in case we can’t obtain it 
                id = default(int);

                // lambda body should be a call 
                if (filter.Body.NodeType != ExpressionType.Call)
                {
                    return false;
                }

                // actually a call to object.Equals(object)
                var callExpression = (MethodCallExpression)filter.Body;
                if (callExpression.Method != EqualsMethodInfo)
                {
                    return false;
                }
                // left side of Equals() should be an access to User.Id
                if (callExpression.Object == null
                    || callExpression.Object.NodeType != ExpressionType.MemberAccess
                    || ((MemberExpression)callExpression.Object).Member != UserIdMemberInfo)
                {
                    return false;
                }

                // There should be only one argument for Equals()
                if (callExpression.Arguments.Count != 1)
                {
                    return false;
                }

                MemberExpression fieldAccess;
                if (callExpression.Arguments[0].NodeType == ExpressionType.Convert)
                {
                    // convert node should have an member access access node
                    // This is for cases when primary key is a value type
                    var convert = (UnaryExpression)callExpression.Arguments[0];
                    if (convert.Operand.NodeType != ExpressionType.MemberAccess)
                    {
                        return false;
                    }
                    fieldAccess = (MemberExpression)convert.Operand;
                }
                else if (callExpression.Arguments[0].NodeType == ExpressionType.MemberAccess)
                {
                    // Get field member for when key is reference type
                    fieldAccess = (MemberExpression)callExpression.Arguments[0];
                }
                else
                {
                    return false;
                }

                // and member access should be a field access to a variable captured in a closure
                if (fieldAccess.Member.MemberType != MemberTypes.Field
                    || fieldAccess.Expression.NodeType != ExpressionType.Constant)
                {
                    return false;
                }

                // expression tree matched so we can now just get the value of the id 
                var fieldInfo = (FieldInfo)fieldAccess.Member;
                var closure = ((ConstantExpression)fieldAccess.Expression).Value;

                id = (int)fieldInfo.GetValue(closure);
                return true;
            }
        }


    }
}
