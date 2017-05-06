using Lq.Service.Models.Attribute;
using System.ComponentModel.DataAnnotations;

namespace Lq.Service.Models.Entity
{
    /// <summary>
    /// 带有空间属性的实体类
    /// </summary>
    public abstract class SpatialEntity : BaseEntity, ISpatialEntity
    {
        [ColumnComment("中心位置坐标")]
        [MaxLength(50)]
        public string Location { get; set; }

        [ColumnComment("轮廓geojson字符串")]
        [MaxLength(500)]
        public string Contour { get; set; }

        [ColumnComment("包含空间对象geojson字符串")]
        [MaxLength(2000)]
        public string Geojson { get; set; }
    }
}
