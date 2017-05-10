using Service.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Store
{
    public interface IUserPermissonStore
    {
        Task<IList<Permission>> GetPermissionsAsync(AdminUser user);


        Task AddPermissionAsync(AdminUser user, string entityName, Action action);


        Task RemovePermissionAsync(AdminUser user, string entityName, Action action);
    }
}
