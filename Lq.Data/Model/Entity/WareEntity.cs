using Lq.Data.Attribute;
using System.ComponentModel.DataAnnotations;

namespace Lq.Data.Model.Entity
{
    public abstract class WareEntity : BaseEntity, IWare
    {
        [ColumnComment("价格")]
        public decimal? Price { get ; set ; }
        [ColumnComment("描述")]
        [MaxLength(200)]
        public string Description { get ; set; }
        [ColumnComment("库存")]
        public int? Stock { get ; set ; }
        [ColumnComment("折扣")]
        public decimal? Discount { get; set; }
    }
}