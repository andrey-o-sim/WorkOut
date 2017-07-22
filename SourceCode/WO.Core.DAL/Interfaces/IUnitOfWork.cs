using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.Core.DAL.Model;

namespace WO.Core.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<T> GetGenericRepository<T>() where T : BaseModel;
        void Commit();
    }
}
