using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;

namespace Lq.Service.Models.Identity
{
    public class UserManager : UserManager<User, int>
    {
        public UserManager(IUserStore<User, int> store)
            : base(store)
        {
            UserValidator= new UserValidator<User, int>(this)
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


        public void SetUserTokenProvider(IDataProtectionProvider provider)
        {
            if(provider!=null)
                UserTokenProvider = new DataProtectorTokenProvider<User, int>(provider.Create("ASP.NET Identity"));
        }
    }
}