using Lq.Data.Attribute;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lq.Data.Model.Security
{
    public class RolePermission : PerssionProperty
    {
        [Key, Column(Order = 1)]
        [ColumnComment("角色id")]
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }

}