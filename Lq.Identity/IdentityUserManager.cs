using Microsoft.AspNet.Identity;

namespace Lq.Identity
{

    public class UserManager<TUser> : UserManager<TUser, int> where TUser : class, IUser<int>
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="store"></param>
        public UserManager(IUserStore<TUser,int> store)
            : base(store)
        {
        }
    }

    public class IdentityUserManager : UserManager<IdentityUser, int>
    {
        public IdentityUserManager(IUserStore<IdentityUser, int> store)
            : base(store)
        {
            UserValidator= new UserValidator<IdentityUser, int>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            
        }
    }
}