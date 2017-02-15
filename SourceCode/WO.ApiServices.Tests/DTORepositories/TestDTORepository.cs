using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.ApiServices.Models;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces.Repositories;

namespace WO.ApiServices.Tests.DTORepositories
{
    public class TestDTORepository<T>: IRepositoryDTO<T> where T :BaseModelDTO
    {
        List<T> _dataCollection;
        public TestDTORepository(List<T> dataCollection)
        {
            _dataCollection = dataCollection;
        }
        public int Create(T item)
        {
            _dataCollection.Add(item);

            item.CreatedDate = DateTime.Now;
            item.ModifiedDate = DateTime.Now;
            item.Id = _dataCollection.Count;

            return _dataCollection.Count;
        }

        public void Delete(int id)
        {
            var item = _dataCollection.Where(dc => dc.Id == id).FirstOrDefault();
            if (item != null)
            {
                _dataCollection.Remove(item);
            }
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return null;
        }

        public T Get(int id)
        {
            return _dataCollection.Where(dc => dc.Id == id).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return _dataCollection;
        }

        public void Update(T item)
        {
            var updateItem = _dataCollection.Where(dc=>dc.Id==item.Id).FirstOrDefault();
            if (updateItem != null)
            {
                _dataCollection.Remove(updateItem);
                _dataCollection.Add(item);
            }
        }
    }
}
