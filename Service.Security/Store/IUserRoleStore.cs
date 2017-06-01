using Service.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Store
{
    public interface IUserRoleStore
    {
        Task<IList<Role>> GetRolesAsync(AdminUser user);


        Task AddRoleAsync(AdminUser user, string roleName);


        Task RemoveRoleAsync(AdminUser user, string roleName);
    }
}
