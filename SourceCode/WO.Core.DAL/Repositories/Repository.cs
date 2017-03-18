using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.Core.DAL.Interfaces;
using WO.Core.DAL.Model;

namespace WO.Core.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        protected DbContext _dbContext;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual int Create(T item)
        {
            _dbContext.Set<T>().Add(item);
            _dbContext.Entry(item).State = EntityState.Added;
            _dbContext.SaveChanges();

            return item.Id;
        }

        public virtual void Update(T item)
        {
            var entry = _dbContext.Entry(item);
            AttachToContext(item, EntityState.Modified);

            entry.Property(i => i.CreatedDate).IsModified = false;
            _dbContext.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            var itemForRemove = _dbContext.Set<T>().Where(item => item.Id == id).FirstOrDefault();
            _dbContext.Set<T>().Remove(itemForRemove);
            _dbContext.Entry(itemForRemove).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }

        public virtual T Find(Func<T, bool> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).FirstOrDefault();
        }

        public virtual IEnumerable<T> FindMany(Func<T, bool> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).ToList();
        }

        public virtual T Get(int id)
        {
            var result = _dbContext.Set<T>().Where(item => item.Id == id).FirstOrDefault();
            return result;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public virtual void AttachToContext<TEntity>(TEntity item, EntityState state) where TEntity : BaseModel
        {
            if (!_dbContext.ChangeTracker.Entries<TEntity>().Any(b => b.Entity.Id == item.Id))
            {
                _dbContext.Set<TEntity>().Attach(item);
                _dbContext.Entry(item).State = state;
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
