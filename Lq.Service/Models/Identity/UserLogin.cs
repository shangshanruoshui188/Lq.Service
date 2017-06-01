using Microsoft.AspNet.Identity.EntityFramework;

namespace Lq.Service.Models.Identity
{
    /// <summary>
    /// user-login one-to-many
    /// </summary>
    public class UserLogin : IdentityUserLogin<int> { }
}