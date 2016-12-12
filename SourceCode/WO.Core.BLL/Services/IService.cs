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
        IOperationResult Create(T item);
        IOperationResult Update(T item);
        IOperationResult Remove(int id);
    }
}
