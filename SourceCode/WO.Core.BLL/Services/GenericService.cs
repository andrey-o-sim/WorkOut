using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces;
using WO.Core.BLL.Services;

namespace WO.Core.BLL.Services
{
    public class GenericService<T> : IService<T> where T : BaseModelDTO
    {
        public IOperationResult Create(T item)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public IOperationResult Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IOperationResult Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
