using Lq.Data.Model.Security;
using System;
using System.Threading.Tasks;
using Lq.Store;

namespace Lq.Manager
{
    public class UserManager : BaseManager<User>, IUserManager
    {
        public UserManager(IUserStore store) : base(store)
        {
        }

        public Task<ServiceResult> CreateAsync(User user, string pwd)
        {
            throw new NotImplementedException();
        }
    }
}
