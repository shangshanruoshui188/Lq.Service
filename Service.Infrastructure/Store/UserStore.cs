using Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Service.Store
{
    public class UserStore<TUser> : BaseStore<TUser>,
        IUserStore<TUser>,
        IUserEmailStore<TUser>,
        IUserPhoneStore<TUser>,
        IUserPwdStore<TUser>,
        IDisposable
        where TUser:User
    {


        public UserStore(IDbContext context)
            : base(context)
        {
        }

        public IQueryable<TUser> Users { get { return store.EntitySet; } }


        #region IUserEmailStore
        public Task<TUser> FindByEmailAsync(string email)
        {
            return FindByProperty("Email",email);
        }

        public Task<string> GetEmailAsync(TUser user)
        {
            CheckNull(user, nameof(user));
            return GetProperty<string>(user,"Email");
        }

        public Task SetEmailAsync(TUser user, string email)
        {
            CheckNull(user, nameof(user));
            return SetProperty(user,"Email",email);
        }
        #endregion

        #region IUserStore
        public Task<TUser> FindByNameAsync(string name)
        {
            return GetUserAggregateAsync(u => u.Name.ToLower().Equals(name.ToLower()));
        }
        #endregion

        #region IUSerPhoneStore
        public Task SetPhoneAsync(TUser user, string phone)
        {
            CheckNull(user, nameof(user));
            user.Phone = phone;
            return Task.FromResult(0);
        }

        public Task<string> GetPhoneAsync(TUser user)
        {
            CheckNull(user, nameof(user));
            return Task.FromResult(user.Phone);
        }

        public Task<TUser> FindByPhone(string phone)
        {
            return GetUserAggregateAsync(u => u.Phone.ToLower().Equals(phone.ToLower()));
        }
        #endregion

        #region IUserPwdStore
        public Task SetPwdHashAsync(TUser user, string pwdHash)
        {
            CheckNull(user, nameof(user));
            user.PwdHash = pwdHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPwdHashAsync(TUser user)
        {
            CheckNull(user, nameof(user));
            return Task.FromResult(user.PwdHash);
        }

        public Task<bool> HasPwdAsync(TUser user)
        {
            CheckNull(user, nameof(user));
            return Task.FromResult(user.PwdHash != null);
        }
        #endregion

        

        #region Helper
        protected virtual async Task<TUser> GetUserAggregateAsync(Expression<Func<TUser, bool>> filter)
        {
            return await GetAggregateAsync(filter);
        }

        

        public override void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
            Context = null;
            store = null;
            base.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion




    }
}
