using Lq.Data.Attribute;
using Lq.Data.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lq.Data.Model.Security
{
    /// <summary>
    /// 用户基表，所有的用户派生自此类，使用Table-Per-Type表达继承关系
    /// </summary>
    public class User : BaseEntity
    {
        [ColumnComment("上次登陆日期")]
        public DateTime LastLoginDate { get; set; }
        [ColumnComment("用户名")]
        [MaxLength(50)]
        public string Name { get; set; }
        [ColumnComment("邮箱")]
        [MaxLength(50)]
        public string Email { get; set; }
        public string PwdHash { get; set; }
        [ColumnComment("电话")]
        [MaxLength(50)]
        public string Phone { get; set; }

        public virtual ICollection<UserPermission> Permissions { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; }


    }
}
