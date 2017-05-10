using Service.Attribute;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Service.Entity
{
    public class Role : BaseEntity
    {
        [ColumnComment("角色名")]
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [ColumnComment("角色描述")]
        [MaxLength(200)]
        public string Description { get; set; }


        public virtual ICollection<UserRole> Users { get; set; }
        public virtual ICollection<RolePermission> Perssions { get; set; }


    }
}
