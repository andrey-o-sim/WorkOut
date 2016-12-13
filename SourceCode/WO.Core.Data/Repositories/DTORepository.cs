using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces.Repositories;
using WO.Core.DAL.Interfaces;

namespace WO.Core.Data.Repositories
{
    public class DTORepository<T> : IRepositoryDTO<T> where T : BaseModelDTO
    {
        IRepository<T> _repository;
        public DTORepository(IRepository<T> repository)
        {
            _repository = repository;
        }
        public int Create(T item)
        {
            return _repository.Create(item);
        }

        public void Update(T item)
        {
            _repository.Update(item);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _repository.Find(predicate);
        }

        public T Get(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
