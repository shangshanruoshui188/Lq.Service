using Service.Attribute;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Entity
{
    public class UserRole:BaseEntity
    {
        [Key,Column(Order=1)]
        [ForeignKey("User")]
        [ColumnComment("用户Id")]
        public int UserId { get; set; }
        [Key, Column(Order = 2)]
        [ForeignKey("Role")]
        [ColumnComment("角色Id")]
        public int RoleId { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
