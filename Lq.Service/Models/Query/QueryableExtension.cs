using Lq.Service.Models.Query;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Lq.Service.Models.Query
{
 
    /// <summary>
    /// 对IQueryable的扩展方法
    /// </summary>
    public static class QueryableExtension
    {
        /// <summary>
        /// 使IQueryable支持QueryModel
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="table">IQueryable的查询对象</param>
        /// <param name="model">QueryModel对象</param>
        /// <param name="prefix">使用前缀区分查询条件</param>
        /// <returns></returns>
        public static IQueryable<TEntity> Where<TEntity>(this IQueryable<TEntity> table, QueryModel model, string prefix = "") where TEntity : class
        {
            Contract.Requires(table != null);
            return Where<TEntity>(table, model.Items, prefix);
        }

        private static IQueryable<TEntity> Where<TEntity>(IQueryable<TEntity> table, ICollection<ConditionItem> items, string prefix = "")
        {
            Contract.Requires(table != null);
            IEnumerable<ConditionItem> filterItems =
                string.IsNullOrWhiteSpace(prefix)
                    ? items.Where(c => string.IsNullOrEmpty(c.Prefix))
                    : items.Where(c => c.Prefix == prefix);
            if (filterItems.Count() == 0) return table;
            return new QueryableSearcher<TEntity>(table, filterItems).Search();
        }
    }
}
