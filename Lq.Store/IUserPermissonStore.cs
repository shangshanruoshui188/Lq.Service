using Lq.Data.Model.Security;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lq.Store
{
    public interface IUserPermissonStore
    {
        Task<IList<Permission>> GetPermissionsAsync(User user);


        Task AddPermissionAsync(User user, string entityName, Data.Model.Security.Action action);


        Task RemovePermissionAsync(User user, string entityName, Data.Model.Security.Action action);
    }
}
