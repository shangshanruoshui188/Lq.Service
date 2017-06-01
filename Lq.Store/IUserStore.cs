using Lq.Data.Model.Security;
using System.Linq;
using System.Threading.Tasks;

namespace Lq.Store
{
    public interface IUserStore:IStore<User>
    {
        IQueryable<User> Users { get;}
        Task<User> FindByNameAsync(string name);
    }
}
