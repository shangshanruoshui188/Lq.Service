using System;

namespace Service.Entity
{
    /// <summary>
    /// 系统使用到的所有实体类型必须实现的接口
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// 主键id
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// 实体创建时间
        /// </summary>
        DateTime CreateDate { get; set; }

        /// <summary>
        /// 实体更新时间
        /// </summary>
        DateTime UpdateDate { get; set; }
    }
}
