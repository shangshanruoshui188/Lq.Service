using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lq.Service.Models.Attribute
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class ColumnCommentAttribute:System.Attribute
    {
        public string Comment { get; set; }

        public ColumnCommentAttribute(string comment)
        {
            Comment = comment;
        }
    }
}
