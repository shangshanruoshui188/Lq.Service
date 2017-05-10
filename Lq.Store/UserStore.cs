using Lq.Data.Model.Security;
using Lq.Store.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Lq.Store
{
    public class UserStore : BaseStore<User>,
        IUserStore,
        IUserEmailStore,
        IUserPhoneStore,
        IUserPwdStore,
        IUserPermissonStore,
        IUserRoleStore,
        IDisposable
    {


        public UserStore(IDbContext context)
            : base(context)
        {
        }

        public IQueryable<User> Users { get { return store.EntitySet; } }


        #region IUserEmailStore
        public Task<User> FindByEmailAsync(string email)
        {
            return GetUserAggregateAsync(u => u.Email.ToLower().Equals(email.ToLower()));
        }

        public Task<string> GetEmailAsync(User user)
        {
            CheckNull(user, nameof(user));
            return Task.FromResult(user.Email);
        }

        public Task SetEmailAsync(User user, string email)
        {
            CheckNull(user, nameof(user));
            user.Email = email;
            return Task.FromResult(0);
        }
        #endregion

        #region IUserStore
        public Task<User> FindByNameAsync(string name)
        {
            return GetUserAggregateAsync(u => u.Name.ToLower().Equals(name.ToLower()));
        }
        #endregion

        #region IUSerPhoneStore
        public Task SetPhoneAsync(User user, string phone)
        {
            CheckNull(user, nameof(user));
            user.Phone = phone;
            return Task.FromResult(0);
        }

        public Task<string> GetPhoneAsync(User user)
        {
            CheckNull(user, nameof(user));
            return Task.FromResult(user.Phone);
        }

        public Task<User> FindByPhone(string phone)
        {
            return GetUserAggregateAsync(u => u.Phone.ToLower().Equals(phone.ToLower()));
        }
        #endregion

        #region IUserPwdStore
        public Task SetPwdHashAsync(User user, string pwdHash)
        {
            CheckNull(user, nameof(user));
            user.PwdHash = pwdHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPwdHashAsync(User user)
        {
            CheckNull(user, nameof(user));
            return Task.FromResult(user.PwdHash);
        }

        public Task<bool> HasPwdAsync(User user)
        {
            CheckNull(user, nameof(user));
            return Task.FromResult(user.PwdHash != null);
        }
        #endregion

        #region IUserPermissionStore

        public virtual async Task<IList<Permission>> GetPermissionsAsync(User user)
        {
            CheckNull(user, nameof(user));
            return await GetTargetsAsync<UserPermission, Permission>(user, up => up.UserId, up => up.PermissionId);
        }



        public virtual async Task AddPermissionAsync(User user, string entityName, Data.Model.Security.Action action)
        {
            CheckNull(user, nameof(user));
            CheckNull(entityName, nameof(entityName));
            CheckNull(action, nameof(action));

            await AddTargetAsync<UserPermission, Permission>(user,
                p => p.Action == action && p.Entity.ToLower().Equals(entityName.ToLower()),
                (u, p) => new UserPermission { UserId = u.Id, PermissionId = p.Id }
                );
        }

        public async Task RemovePermissionAsync(User user, string entityName, Data.Model.Security.Action action)
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
        public virtual async Task<IList<Role>> GetRolesAsync(User user)
        {
            CheckNull(user, nameof(user));
            return await GetTargetsAsync<UserRole, Role>(user, ur => ur.UserId, ur => ur.RoleId);
        }



        public virtual async Task AddRoleAsync(User user, string roleName)
        {
            CheckNull(user, nameof(user));
            CheckNull(roleName, nameof(roleName));

            await AddTargetAsync<UserRole, Role>(user,
                r => r.Name.ToLower().Equals(roleName),
                (u, r) => new UserRole { UserId = u.Id, RoleId = r.Id }
                );
        }

        public async Task RemoveRoleAsync(User user, string roleName)
        {
            CheckNull(user, nameof(user));
            CheckNull(roleName, nameof(roleName));

            await RemoveTargetAsync<UserRole, Role>(user,
                r => r.Name.ToLower().Equals(roleName),
                ur => ur.UserId,
                ur => ur.RoleId);
        }
        #endregion

        #region Helper
        protected virtual async Task<User> GetUserAggregateAsync(Expression<Func<User, bool>> filter)
        {
            return await GetAggregateAsync(filter);
        }

        private void CheckNull(object obj, string name)
        {
            if (obj == null)
                throw new ArgumentNullException(name);
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
            Context = null;
            store = null;
            GC.SuppressFinalize(this);
        }
        #endregion




    }
}
