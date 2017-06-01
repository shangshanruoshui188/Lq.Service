using Lq.Service.Models.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Lq.Service.Models.Store
{
    public abstract class BaseStore<TEntity> : IStore<TEntity> where TEntity : BaseEntity
    {

        public bool AutoSaveChanges { get; set; }
        public DbContext Context { get; private set; }
        public IQueryable<TEntity> EntitySet { get { return DbEntitySet; } } 

        public DbSet<TEntity> DbEntitySet { get; private set; }

        public BaseStore(DbContext context) {
            Context = context;
            DbEntitySet = Context.Set<TEntity>();
            AutoSaveChanges = true;
        }

        public async Task CreateAsync(TEntity entity)
        {
            DbEntitySet.Add(entity);
            await SaveChanges();

        }

        public async Task DeleteAsync(TEntity entity)
        {
            DbEntitySet.Remove(entity);
            await SaveChanges();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbEntitySet.FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }


        private async Task SaveChanges()
        {
            if (AutoSaveChanges)
            {
                await Context.SaveChangesAsync();
            }
        }
    }
}