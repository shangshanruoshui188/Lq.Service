using Lq.Service.Models.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lq.Service.Models.Entity
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