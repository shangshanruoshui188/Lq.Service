using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Lq.Service.Models.Entity;
using System;
using System.Collections.Generic;
using Lq.Service.Models.Attribute;

namespace Lq.Service.Models.Identity
{
    /// <summary>
    /// undependent model
    /// </summary>
    public class User : IdentityUser<int, UserLogin, UserRole, UserClaim>, IEntity
    {
        [ColumnComment("创建日期")]
        public DateTime CreateDate { get; set; }
        [ColumnComment("更新日期")]
        public DateTime UpdateDate { get; set; }
        [ColumnComment("上次登陆日期")]
        public DateTime LastLoginDate { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }

        public virtual ICollection<UserPermission> Permissions { get; set; }
    }
}