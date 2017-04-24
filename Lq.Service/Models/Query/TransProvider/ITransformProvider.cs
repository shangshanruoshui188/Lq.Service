using System;
using System.Collections.Generic;


namespace Lq.Service.Models.Query.TransProvider
{

    public interface ITransformProvider
    {
        bool Match(ConditionItem item, Type type);
        IEnumerable<ConditionItem> Transform(ConditionItem item, Type type);
    }
}