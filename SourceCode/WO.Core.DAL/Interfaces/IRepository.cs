using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WO.Core.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Find(Func<T, bool> predicate);
        IEnumerable<T> FindMany(Func<T, bool> predicate);
        int Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
