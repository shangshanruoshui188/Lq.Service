using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Lq.Identity
{
    /// <summary>
    /// undependent model
    /// </summary>
    public class IdentityUser : IdentityUser<int, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<IdentityUser, int> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }


    }
}