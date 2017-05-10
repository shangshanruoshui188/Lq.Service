using Service.Entity;
using Service.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Store
{
    public class AdminUserStore : UserStore<AdminUser>, IUserRoleStore, IUserPermissonStore
    {
        public AdminUserStore(IDbContext context) : base(context)
        {
        }

        #region IUserPermissionStore

        public virtual async Task<IList<Permission>> GetPermissionsAsync(AdminUser user)
        {
            CheckNull(user, nameof(user));
            return await GetTargetsAsync<UserPermission, Permission>(user, up => up.UserId, up => up.PermissionId);
        }



        public virtual async Task AddPermissionAsync(AdminUser user, string entityName, Entity.Action action)
        {
            CheckNull(user, nameof(user));
            CheckNull(entityName, nameof(entityName));
            CheckNull(action, nameof(action));

            await AddTargetAsync<UserPermission, Permission>(user,
                p => p.Action == action && p.Entity.ToLower().Equals(entityName.ToLower()),
                (u, p) => new UserPermission { UserId = u.Id, PermissionId = p.Id }
                );
        }

        public async Task RemovePermissionAsync(AdminUser user, string entityName, Entity.Action action)
        {
            CheckNull(user, nameof(user));
            CheckNull(entityName, nameof(entityName));
            CheckNull(action, nameof(action));
            await RemoveTargetAsync<UserPermission, Permission>(user,
                p => p.Action == action && p.Entity.ToLower().Equals(entityName.ToLower()),
                up => up.UserId,
                up => up.PermissionId);
        }
        #endregion

        #region IUserRoleStore
        public virtual async Task<IList<Role>> GetRolesAsync(AdminUser user)
        {
            CheckNull(user, nameof(user));
            return await GetTargetsAsync<UserRole, Role>(user, ur => ur.UserId, ur => ur.RoleId);
        }



        public virtual async Task AddRoleAsync(AdminUser user, string roleName)
        {
            CheckNull(user, nameof(user));
            CheckNull(roleName, nameof(roleName));

            await AddTargetAsync<UserRole, Role>(user,
                r => r.Name.ToLower().Equals(roleName),
                (u, r) => new UserRole { UserId = u.Id, RoleId = r.Id }
                );
        }

        public async Task RemoveRoleAsync(AdminUser user, string roleName)
        {
            CheckNull(user, nameof(user));
            CheckNull(roleName, nameof(roleName));

            await RemoveTargetAsync<UserRole, Role>(user,
                r => r.Name.ToLower().Equals(roleName),
                ur => ur.UserId,
                ur => ur.RoleId);
        }
        #endregion

    }
}
