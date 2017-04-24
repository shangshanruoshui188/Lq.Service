using Lq.Service.Models.Attribute;
using Lq.Service.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lq.Service.Models
{
    public class Permission:BaseEntity
    {
        [ColumnComment("权限对应的实体类型")]
        [MaxLength(20)]
        public string Entity { get; set; }
        [ColumnComment("权限动作类型")]
        public Action Action { get; set; }
        [ColumnComment("权限描述")]
        [MaxLength(20)]
        public string Description { get; set; }

        //多对多 如果第三表不包括其他字段直接ICollection<User> Users,否则分成两个多对多
        public virtual ICollection<UserPermission> Users { get; set; }
        public virtual ICollection<RolePermission> Roles { get; set; }

        public override string ToString()
        {
            return string.Format("{0}-{1}",Entity,Action);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            if(obj is Permission)
            {
                Permission p = obj as Permission;
                return Entity.Equals(p.Entity, StringComparison.OrdinalIgnoreCase) && this.Action == p.Action;
            }

            return false;
        }

    }

    public enum Action
    {
        Retrive=0,
        Create,
        Update,
        Delete
    }

    public class PerssionProperty : BaseEntity
    {
        [Key, Column(Order = 2)]
        [ColumnComment("权限id")]
        [ForeignKey("Permission")]
        public int PermissionId { get; set; }

        [ColumnComment("可授予")]
        public bool CanGrant { get; set; }
        [ColumnComment("可回收")]
        public bool CanRevoke { get; set; }
        [ColumnComment("授权人id")]
        public int? GrantorId { get; set; }
        [ColumnComment("授权日期")]
        public DateTime GrantDate { get; set; }

        public virtual Permission Permission { get; set; }
    }


    public class UserPermission : PerssionProperty
    {
        [Key,Column(Order =1)]
        [ColumnComment("用户id")]
        [ForeignKey("User")]
        public int UserId { get; set; }
        

        public virtual User User { get; set; }
    }

    public class RolePermission : PerssionProperty
    {
        [Key, Column(Order = 1)]
        [ColumnComment("角色id")]
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }

}