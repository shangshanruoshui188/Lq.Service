using Microsoft.AspNet.Identity.EntityFramework;

namespace Lq.Identity
{
    public class IdentityUserStore : UserStore<IdentityUser, IdentityRole, int, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        public IdentityUserStore(IdentityDbContext context)
            : base(context)
        {
        }
    }
}