using Service.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Store
{
    public interface IUserStore<TUser>:IStore<TUser> where TUser:IUser
    {
        IQueryable<TUser> Users { get;}
        Task<TUser> FindByNameAsync(string name);
    }
}
