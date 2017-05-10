using Service.Entity;
using System.Threading.Tasks;

namespace Service.Store
{
    public interface IUserPhoneStore<TUser> where TUser:IUser
    {
        Task SetPhoneAsync(TUser user, string phone);
        Task<string> GetPhoneAsync(TUser user);
        Task<TUser> FindByPhone(string phone);
    }
}
