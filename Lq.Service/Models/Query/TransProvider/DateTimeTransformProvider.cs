using Lq.Service.Models.Util;
using System;
using System.Collections.Generic;


namespace Lq.Service.Models.Query.TransProvider
{

    public class DateTimeTransformProvider : ITransformProvider
    {
        public bool Match(ConditionItem item, Type type)
        {
            var realType = TypeUtil.GetUnNullableType(type);
            return realType == typeof(DateTime)
                   && !(item.Value is DateTime)
                   && (item.Method == QueryMethod.LessThan || item.Method == QueryMethod.LessThanOrEqual);
        }

        public IEnumerable<ConditionItem> Transform(ConditionItem item, Type type)
        {
            DateTime willTime;
            DateTime.TryParse(item.Value.ToString(), out willTime);
            if (willTime.Hour == 0 && willTime.Minute == 0 && willTime.Second == 0)
            {
                willTime = willTime.AddDays(1).AddMilliseconds(-1);
            }
            return new[] { new ConditionItem(item.Field, QueryMethod.LessThanOrEqual, willTime) };
        }
    }
}