using System;

namespace Lq.Service.Models.Attribute
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class EntityMapAttribute : System.Attribute
    {
        private readonly string entityName;


        public EntityMapAttribute() { }

        public EntityMapAttribute(string entityName)
        {
            this.entityName = entityName;
        }

        public string EntityName
        {
            get
            {
                return entityName;
            }
        }

    }
}
