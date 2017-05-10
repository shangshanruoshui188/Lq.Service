using Service.Attribute;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Entity
{
    /// <summary>
    /// 权限属性
    /// </summary>
    public class PerssionProperty : BaseEntity
    {
        [Key, Column(Order = 2)]
        [ColumnComment("权限id")]
        [ForeignKey("Permission")]
        public int PermissionId { get; set; }


        public virtual Permission Permission { get; set; }
    }

}