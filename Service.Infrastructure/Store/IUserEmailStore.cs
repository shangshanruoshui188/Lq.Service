using Service.Entity;
using System.Threading.Tasks;

namespace Service.Store
{
    public interface IUserEmailStore<TUser> where TUser:IUser
    {
        Task SetEmailAsync(TUser user,string email);
        Task<string> GetEmailAsync(TUser user);
        Task<TUser> FindByEmailAsync(string email);
    }
}
