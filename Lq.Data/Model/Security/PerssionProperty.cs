using Lq.Data.Attribute;
using Lq.Data.Model.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lq.Data.Model.Security
{
    /// <summary>
    /// 权限属性，权限可定义是否可授权，是否可回收
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