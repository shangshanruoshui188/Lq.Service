using Microsoft.AspNet.Identity.EntityFramework;

namespace Lq.Identity
{
    public class IdentityRoleStore : RoleStore<IdentityRole, int, IdentityUserRole>
    {
        public IdentityRoleStore(IdentityDbContext context)
            : base(context)
        {
        }
    }
}