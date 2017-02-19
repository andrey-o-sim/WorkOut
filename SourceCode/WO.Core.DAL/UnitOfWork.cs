using System;
using System.Threading.Tasks;
using WO.Core.DAL.DataBaseContext;
using WO.Core.DAL.Interfaces;
using WO.Core.DAL.Model;
using WO.Core.DAL.Repositories;

namespace WO.Core.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private static WorkOutContext _woContext;
        private bool disposed = false;

        public UnitOfWork(string contextName)
        {
            _woContext = new WorkOutContext(contextName);
        }

        public IRepository<T> GetGenericRepository<T>() where T : BaseModel
        {
            return new Repository<T>(_woContext);
        }

        #region Properties Of Repositories
        #endregion

        public async Task SaveAsync()
        {
            await _woContext.SaveChangesAsync();
        }

        #region Dispose Context
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _woContext.Dispose();
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
