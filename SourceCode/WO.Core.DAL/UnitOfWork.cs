using System;
using WO.Core.DAL.DataBaseContext;
using WO.Core.DAL.Interfaces;
using WO.Core.DAL.Model;
using WO.Core.DAL.Repositories;

namespace WO.Core.DAL
{
    public class UnitOfWork : IDisposable
    {
        private static WorkOutContext _woContext;

        public UnitOfWork()
        {
            _woContext = new WorkOutContext("WorkOutDbConnection");
        }

        public IRepository<T> GetGenericRepository<T>() where T : BaseModel
        {
            return new Repository<T>(_woContext);
        }

        #region Properties Of Repositories
        #endregion

        #region Dispose Context
        private bool disposed = false;
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
