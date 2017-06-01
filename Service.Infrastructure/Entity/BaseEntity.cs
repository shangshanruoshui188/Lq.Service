using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using Service.Attribute;

namespace Service.Entity
{
    /// <summary>
    /// 所有实体类型必须继承的基类
    /// </summary>
    public abstract class BaseEntity : IEntity
    {
        private static Dictionary<string, Type> entityMap;

        /// <summary>
        /// 主键Id
        /// </summary>
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
        /// <summary>
        /// 实体创建时间
        /// </summary>
        [ColumnComment("创建时间")]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 实体更新时间
        /// </summary>
        [ColumnComment("更新时间")]
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// 实体创建者Id
        /// </summary>
        [ColumnComment("创建者id")]
        public int? CreatorId { get; set; }

    }

}
