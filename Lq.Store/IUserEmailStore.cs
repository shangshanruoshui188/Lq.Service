using Lq.Data.Model.Security;
using System.Threading.Tasks;

namespace Lq.Store
{
    public interface IUserEmailStore
    {
        Task SetEmailAsync(User user,string email);
        Task<string> GetEmailAsync(User user);
        Task<User> FindByEmailAsync(string email);
    }
}
