using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using Service.Entity;

namespace Service.Store
{
    internal class EntityStore<TEntity> : Service.Store.IEntityStore<TEntity> where TEntity : BaseEntity
    {

        public IDbContext Context { get; private set; }
        public IQueryable<TEntity> EntitySet { get { return DbEntitySet; } } 

        public DbSet<TEntity> DbEntitySet { get; private set; }

        public EntityStore(IDbContext context) {
            Context = context;
            DbEntitySet = Context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            DbEntitySet.Add(entity);

        }

        public void Delete(TEntity entity)
        {
            DbEntitySet.Remove(entity);
        }

        public virtual Task<TEntity> FindByIdAsync(int id)
        {
            return DbEntitySet.FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}