using Service.Entity;
using System.Threading.Tasks;

namespace Service.Manager
{
    public interface IUserManager<TUser> : IManager<TUser> where TUser:IUser
    {
        Task CreateAsync(TUser user, string pwd);

    }
}
