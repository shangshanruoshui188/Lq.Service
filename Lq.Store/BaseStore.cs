using Lq.Data.Model.Entity;
using Lq.Store.DbContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Lq.Store
{
    public class BaseStore<TEntity> : IStore<TEntity> where TEntity : BaseEntity
    {
        public IDbContext Context { get; protected set; }
        protected IEntityStore<TEntity> store;
        protected bool diposed;
        public bool AutoSaveChanges { get; set; }

        public BaseStore(IDbContext context)
        {
            Context = context;
            AutoSaveChanges = true;
            store = new EntityStore<TEntity>(Context);
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            store.Create(entity);
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
            await SaveChanges();
        }

        private async Task SaveChanges()
        {
            if (AutoSaveChanges)
            {
                await Context.SaveChangesAsync();
            }
        }

        #region 一对多关系的处理
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

        protected virtual async Task EnsureNavigationPropertyLoaded<TProperty>(TEntity entity, Func<TProperty, int> foreignKey, Expression<Func<TEntity, ICollection<TProperty>>> property) 
            where TProperty :class
        {
            if (!AreNavigationPropertyLoaded(entity,property))
            {
                int id = entity.Id;
                await Context.Set<TProperty>().Where(t=>foreignKey(t)==id).LoadAsync();
                Context.Entry(entity).Collection(property).IsLoaded = true;
            }
        }

        protected bool AreNavigationPropertyLoaded<TProperty>(TEntity entity, Expression<Func<TEntity, ICollection<TProperty>>> property) 
            where TProperty:class
        {
            return Context.Entry(entity).Collection(property).IsLoaded;
        }

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

        public void Dispose()
        {
            if (!diposed)
            {
                Context.Dispose();
                diposed = true;
            }
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
