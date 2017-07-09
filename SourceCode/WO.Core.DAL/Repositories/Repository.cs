using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public virtual void Create(T item)
        {
            _dbContext.Set<T>().Add(item);
            _dbContext.Entry(item).State = EntityState.Added;
        }

        public virtual void Update(T item)
        {
            var entry = _dbContext.Entry(item);

            entry.State = EntityState.Modified;
            entry.Property(i => i.CreatedDate).IsModified = false;
        }

        public virtual void Delete(T item)
        {
            _dbContext.Set<T>().Remove(item);
            _dbContext.Entry(item).State = EntityState.Deleted;
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
            var result = _dbContext.Set<T>().Find(id);
            return result;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
