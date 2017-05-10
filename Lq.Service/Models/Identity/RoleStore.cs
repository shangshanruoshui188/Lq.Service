using Microsoft.AspNet.Identity.EntityFramework;

namespace Lq.Service.Models.Identity
{
    public class RoleStore : RoleStore<Role, int, UserRole>
    {
        public RoleStore(AppDbContext context)
            : base(context)
        {
        }
    }
}