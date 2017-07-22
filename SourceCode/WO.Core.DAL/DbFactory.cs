using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.Core.DAL.DataBaseContext;
using WO.Core.DAL.Interfaces;

namespace WO.Core.DAL
{
    public class DbFactory : IDbFactory, IDisposable
    {
        private WorkOutContext _woContext;
        private bool disposed = false;

        public WorkOutContext Init()
        {
            return _woContext ?? (_woContext = new WorkOutContext("WorkOutDbConnection"));
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
