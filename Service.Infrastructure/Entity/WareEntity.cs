using Service.Attribute;
using System.ComponentModel.DataAnnotations;

namespace Service.Entity
{
    /// <summary>
    /// 所有商品实体需要继承的基类
    /// </summary>
    public abstract class WareEntity : BaseEntity, IWare
    {
        /// <summary>
        /// 价格
        /// </summary>
        [ColumnComment("价格")]
        public decimal? Price { get ; set ; }

        /// <summary>
        /// 描述
        /// </summary>
        [ColumnComment("描述")]
        [MaxLength(200)]
        public string Description { get ; set; }

        /// <summary>
        /// 库存
        /// </summary>
        [ColumnComment("库存")]
        public int? Stock { get ; set ; }


        /// <summary>
        /// 折扣
        /// </summary>
        [ColumnComment("折扣")]
        public decimal? Discount { get; set; }
    }
}