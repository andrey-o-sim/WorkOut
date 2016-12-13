using System;
using System.Collections.Generic;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces;
using WO.Core.BLL.Interfaces.Repositories;

namespace WO.Core.BLL.Services
{
    public class GenericService<T> : IService<T> where T : BaseModelDTO
    {
        IRepositoryDTO<T> _repository;
        public GenericService(IRepositoryDTO<T> repository)
        {
            _repository = repository;
        }
        public IOperationResult Create(T item)
        {
            var resultItemId = _repository.Create(item);
            var result = new OperationResult { ResultItemId = resultItemId, Succeed = true };
            return result;
        }

        public T Get(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public IOperationResult Remove(int id)
        {
            _repository.Delete(id);
            var result = new OperationResult { ResultItemId = id, Succeed = true };
            return result;
        }

        public IOperationResult Update(T item)
        {
            _repository.Update(item);
            var result = new OperationResult { ResultItemId = item.Id, Succeed = true };
            return result;
        }
    }
}
