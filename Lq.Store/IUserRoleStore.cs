using Lq.Data.Model.Security;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lq.Store
{
    public interface IUserRoleStore
    {
        Task<IList<Role>> GetRolesAsync(User user);


        Task AddRoleAsync(User user, string roleName);


        Task RemoveRoleAsync(User user, string roleName);
    }
}
