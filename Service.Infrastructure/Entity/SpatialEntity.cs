using Service.Attribute;
using System.ComponentModel.DataAnnotations;

namespace Service.Entity
{
    /// <summary>
    /// 带有空间属性的实体类
    /// </summary>
    public abstract class SpatialEntity : BaseEntity, ISpatialEntity
    {
        /// <summary>
        /// 实体中心位置坐标
        /// </summary>
        [ColumnComment("中心位置坐标")]
        [MaxLength(50)]
        public string Location { get; set; }


        /// <summary>
        /// 实体轮廓geojson字符串
        /// </summary>
        [ColumnComment("轮廓geojson字符串")]
        [MaxLength(500)]
        public string Contour { get; set; }

        /// <summary>
        /// 实体总体geojson字符串
        /// </summary>
        [ColumnComment("包含空间对象geojson字符串")]
        [MaxLength(2000)]
        public string GeoJson { get; set; }
    }
}
