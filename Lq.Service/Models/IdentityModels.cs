using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Lq.Service.Models.Entity;
using System;
using System.Collections.Generic;
using Lq.Service.Models.Attribute;
using System.ComponentModel.DataAnnotations;
using Microsoft.Owin;

namespace Lq.Service.Models
{

    public class UserManager : UserManager<User, int>
    {
        public UserManager(IUserStore<User, int> store)
            : base(store)
        {
        }

        public static UserManager Create(IdentityFactoryOptions<UserManager> options, IOwinContext context)
        {
            var manager = new UserManager(new UserStore(context.Get<AppDbContext>()));
            manager.UserValidator = new UserValidator<User, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<User, int>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

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

    /// <summary>
    /// user-role many-to-many
    /// </summary>
    public class UserRole : IdentityUserRole<int> { }

    /// <summary>
    /// user-claim one-to-many
    /// </summary>
    public class UserClaim : IdentityUserClaim<int> { }


    /// <summary>
    /// user-login one-to-many
    /// </summary>
    public class UserLogin : IdentityUserLogin<int> { }


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

    public class UserStore : UserStore<User, Role, int, UserLogin, UserRole, UserClaim>
    {
        public UserStore(AppDbContext context)
            : base(context)
        {
        }
    }

    public class RoleStore : RoleStore<Role, int, UserRole>
    {
        public RoleStore(AppDbContext context)
            : base(context)
        {
        }
    }
}