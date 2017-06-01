using Lq.Data.Model.Security;
using System.Threading.Tasks;

namespace Lq.Store
{
    public interface IUserPhoneStore
    {
        Task SetPhoneAsync(User user, string phone);
        Task<string> GetPhoneAsync(User user);
        Task<User> FindByPhone(string phone);
    }
}
