using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces.Repositories;
using WO.Core.DAL.Interfaces;
using WO.Core.DAL.Model;

namespace WO.Core.Data.Repositories
{
    public class DTORepository<TBll, TDto> : IRepositoryDTO<TDto> where TBll : BaseModel where TDto : BaseModelDTO
    {
        IRepository<TBll> _repository;
        public DTORepository(IRepository<TBll> repository)
        {
            _repository = repository;
        }
        public int Create(TDto item)
        {
            //convert DTO to BLL
            return _repository.Create(null);
        }

        public void Update(TDto item)
        {
            _repository.Update(null);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<TDto> Find(Func<TDto, bool> predicate)
        {
            return null;
            //return _repository.Find(predicate);
        }

        public TDto Get(int id)
        {
            return null;
            //return _repository.Get(id);
        }

        public IEnumerable<TDto> GetAll()
        {
            return null;
            //return _repository.GetAll();
        }
    }
}
