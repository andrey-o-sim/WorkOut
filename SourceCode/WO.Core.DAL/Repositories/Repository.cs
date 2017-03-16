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
        private DbContext _dbContext;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(T item)
        {
            _dbContext.Set<T>().Add(item);
            _dbContext.Entry(item).State = EntityState.Added;
            _dbContext.SaveChanges();

            return item.Id;
        }

        public void Update(T item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var itemForRemove = _dbContext.Set<T>().Where(item => item.Id == id).FirstOrDefault();
            _dbContext.Set<T>().Remove(itemForRemove);
            _dbContext.Entry(itemForRemove).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }

        public T Find(Func<T, bool> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).FirstOrDefault();
        }

        public IEnumerable<T> FindMany(Func<T, bool> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).ToList();
        }

        public T Get(int id)
        {
            var result = _dbContext.Set<T>().Where(item => item.Id == id).FirstOrDefault();
            return result;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void AttachToContext<TEntity>(TEntity item) where TEntity : class
        {
            _dbContext.Set<TEntity>().Attach(item);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
