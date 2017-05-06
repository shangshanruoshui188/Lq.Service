using System;

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
