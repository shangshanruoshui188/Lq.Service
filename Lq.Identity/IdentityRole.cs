using Microsoft.AspNet.Identity.EntityFramework;

namespace Lq.Identity
{
    /// <summary>
    /// undependent model
    /// </summary>
    public class IdentityRole : IdentityRole<int, IdentityUserRole>
    {
        public IdentityRole() { }
        public IdentityRole(string name) { Name = name; }

    }
}