using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Lq.Service.Models.Query
{


    /// <summary>
    /// 用户自动收集搜索条件的Model
    /// </summary>
    public class QueryModel
    {
        public QueryModel()
        {
            Items = new List<ConditionItem>();
        }

        public QueryModel(NameValueCollection collection):this()
        {

            var keys = collection.AllKeys.Where(c => c.StartsWith("["));

            foreach (var key in keys)
            {

                var val = collection[key];
                //处理无值的情况
                if (string.IsNullOrEmpty(val)) continue;
                AddSearchItem(this, key, val);
            }

        }
        private static void AddSearchItem(QueryModel model, string key, string val)
        {
            string field = "", prefix = "", orGroup = "", method = "";
            var keywords = key.Split(']', ')', '}');
            //将Html中的name分割为我们想要的几个部分
            foreach (var keyword in keywords)
            {
                if (Char.IsLetterOrDigit(keyword[0])) field = keyword;
                var last = keyword.Substring(1);
                if (keyword[0] == '(') prefix = last;
                if (keyword[0] == '[') method = last;
                if (keyword[0] == '{') orGroup = last;
            }
            if (string.IsNullOrEmpty(method)) return;
            if (!string.IsNullOrEmpty(field))
            {
                var item = new ConditionItem
                {
                    Field = field,
                    Value = val.Trim(),
                    Prefix = prefix,
                    OrGroup = orGroup,
                    Method = (QueryMethod)Enum.Parse(typeof(QueryMethod), method)
                };
                model.Items.Add(item);
            }
        }
        /// <summary>
        /// 查询条件
        /// </summary>
        public List<ConditionItem> Items { get; set; }     

    }
}