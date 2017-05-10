using Microsoft.AspNet.Identity.EntityFramework;
using Lq.Service.Models.Entity;
using System;
using System.Collections.Generic;
using Lq.Service.Models.Attribute;
using System.ComponentModel.DataAnnotations;

namespace Lq.Service.Models.Identity
{
    /// <summary>
    /// undependent model
    /// </summary>
    public class Role : IdentityRole<int, UserRole>, IEntity
    {
        public Role() { }
        public Role(string name) { Name = name; }

        [ColumnComment("创建时间")]
        public DateTime CreateDate { get; set; }
        [ColumnComment("更新时间")]
        public DateTime UpdateDate { get; set; }

        [ColumnComment("创建者id")]
        public int CreatorId { get; set; }

        [ColumnComment("角色描述")]
        [MaxLength(50)]
        public string Description { get; set; }

        public virtual ICollection<RolePermission> Permissions { get; set; }
    }
}