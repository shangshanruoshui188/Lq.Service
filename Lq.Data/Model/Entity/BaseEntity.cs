using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using Lq.Data.Attribute;

namespace Lq.Data.Model.Entity
{
    public abstract class BaseEntity : IEntity
    {
        private static Dictionary<string, Type> entityMap;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get; set;
        }

        public static Dictionary<string, Type> EntityMap
        {
            get
            {
                if (entityMap == null)
                {
                    entityMap = typeof(BaseEntity).Assembly.GetTypes()
                        .Where(t => t.GetInterface("Lq.Data.Model.Entity.IEntity") != null)//独立实体类必须实现IEntity接口
                        .ToDictionary(t => t.Name.ToLower());

                }
                return entityMap;
            }
        }
        [ColumnComment("创建时间")]
        public DateTime CreateDate { get; set; }
        [ColumnComment("更新时间")]
        public DateTime UpdateDate { get; set; }
        [ColumnComment("创建者id")]
        public int? CreatorId { get; set; }

    }

}
