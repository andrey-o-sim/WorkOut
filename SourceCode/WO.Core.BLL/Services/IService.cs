using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.Core.BLL.Interfaces;

namespace WO.Core.BLL.Services
{
    public interface IService<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        T Find(Func<T, bool> predicate);
        IEnumerable<T> FindMany(Func<T, bool> predicate);
        IOperationResult Create(T item);
        IOperationResult Update(T item);
        IOperationResult Delete(int id);
    }
}
