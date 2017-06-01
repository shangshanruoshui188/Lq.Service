using Lq.Data.Model.Security;
using System.Threading.Tasks;

namespace Lq.Manager
{
    public interface IUserManager : IManager<User>
    {
        Task<ServiceResult> CreateAsync(User user, string pwd);


    }
}
