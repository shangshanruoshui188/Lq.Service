using System;
using System.Collections.Generic;
namespace Lq.Service.Models.Query.TransProvider
{


    public class LessDateTransformProvider : ITransformProvider
    {
        public bool Match(ConditionItem item, Type type)
        {
            return true;
            
        }

        public IEnumerable<ConditionItem> Transform(ConditionItem item, Type type)
        {
            throw new NotImplementedException();
        }
    }
}