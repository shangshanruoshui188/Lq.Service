using System;
using System.Threading.Tasks;
using Service.Store;
using Service.Entity;

namespace Service.Manager
{
    public class UserManager<TUser> : BaseManager<TUser>, IUserManager<TUser> where TUser:User
    {
        public UserManager(IUserStore<TUser> store) : base(store)
        {

        }

        public Task CreateAsync(TUser user, string pwd)
        {
            throw new NotImplementedException();
        }
    }
}
