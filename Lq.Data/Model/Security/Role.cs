using Lq.Data.Attribute;
using Lq.Data.Model.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lq.Data.Model.Security
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
