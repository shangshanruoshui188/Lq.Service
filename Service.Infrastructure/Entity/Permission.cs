using Service.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Entity
{
    /// <summary>
    /// 权限类，每个权限由权限作用的实体类型和动作类型唯一确定，实体类型应该为全体实体集合的真子集。
    /// 权限和用户，权限和角色，用户和角色都是多对多的关系，用户的权限由用户权限和用户所属角色的权限共同组成
    /// </summary>
    public class Permission:BaseEntity
    {
        [Key,Column(Order=1)]
        [ColumnComment("权限对应的实体类型")]
        [MaxLength(50)]
        public string Entity { get; set; }
        [Key, Column(Order = 2)]
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

}