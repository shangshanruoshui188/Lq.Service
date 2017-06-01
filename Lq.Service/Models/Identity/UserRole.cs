using Microsoft.AspNet.Identity.EntityFramework;

namespace Lq.Service.Models.Identity
{
    /// <summary>
    /// user-role many-to-many
    /// </summary>
    public class UserRole : IdentityUserRole<int> { }
}