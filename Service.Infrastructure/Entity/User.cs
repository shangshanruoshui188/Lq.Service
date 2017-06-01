using Service.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Service.Entity
{
    public class User:BaseEntity,IUser
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
