using Microsoft.AspNet.Identity.EntityFramework;

namespace Lq.Service.Models.Identity
{
    public class UserStore : UserStore<User, Role, int, UserLogin, UserRole, UserClaim>
    {
        public UserStore(AppDbContext context)
            : base(context)
        {
        }
    }
}