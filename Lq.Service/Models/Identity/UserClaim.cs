using Microsoft.AspNet.Identity.EntityFramework;

namespace Lq.Service.Models.Identity
{
    /// <summary>
    /// user-claim one-to-many
    /// </summary>
    public class UserClaim : IdentityUserClaim<int> { }
}