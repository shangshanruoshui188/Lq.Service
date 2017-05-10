using Lq.Data.Model.Security;
using System.Threading.Tasks;

namespace Lq.Store
{
    public interface IUserPwdStore
    {
        Task SetPwdHashAsync(User user, string pwdHash);


        Task<string> GetPwdHashAsync(User user);


        Task<bool> HasPwdAsync(User user);
    }
}
