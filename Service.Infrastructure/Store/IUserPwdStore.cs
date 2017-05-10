using Service.Entity;
using System.Threading.Tasks;

namespace Service.Store
{
    public interface IUserPwdStore<TUser> where TUser:IUser
    {
        Task SetPwdHashAsync(TUser user, string pwdHash);


        Task<string> GetPwdHashAsync(TUser user);


        Task<bool> HasPwdAsync(TUser user);
    }
}
