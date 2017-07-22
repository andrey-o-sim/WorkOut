using WO.Core.DAL.DataBaseContext;
using WO.Core.DAL.Interfaces;
using WO.Core.DAL.Model;
using WO.Core.DAL.Repositories;

namespace WO.Core.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbFactory _dbFactory;
        private WorkOutContext _woContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this._dbFactory = dbFactory;
            _woContext = _dbFactory.Init();
        }

        public IRepository<T> GetGenericRepository<T>() where T : BaseModel
        {
            return new Repository<T>(_woContext);
        }

        #region Properties Of Repositories
        #endregion

        public void Commit()
        {
           _woContext.Commit();
        }
    }
}
