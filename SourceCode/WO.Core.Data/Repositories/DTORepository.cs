using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces.Repositories;
using WO.Core.DAL.Interfaces;
using WO.Core.DAL.Model;
using WO.Core.Data.Configs;

namespace WO.Core.Data.Repositories
{
    public class DTORepository<TData, TDto> : IRepositoryDTO<TDto> where TData : BaseModel where TDto : BaseModelDTO
    {
        IRepository<TData> _repository;
        IMapper _mapper;
        public DTORepository(IRepository<TData> repository)
        {
            _repository = repository;
            _mapper = AutoMapperDataConfiguration.MapperConfiguration.CreateMapper();
        }
        public int Create(TDto item)
        {
            var dbItem = _mapper.Map<TData>(item);
            dbItem.CreatedDate = DateTime.Now;
            dbItem.ModifiedDate = DateTime.Now;

            return _repository.Create(dbItem);
        }

        public void Update(TDto item)
        {
            var dbItem = _mapper.Map<TData>(item);
            dbItem.ModifiedDate = DateTime.Now;

            _repository.Update(dbItem);
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
            var dbItem = _repository.Get(id);
            var dataItem = _mapper.Map<TDto>(dbItem);
            return dataItem;
        }

        public IEnumerable<TDto> GetAll()
        {
            var dbItem = _repository.GetAll();
            var dataItem = _mapper.Map<List<TDto>>(dbItem);
            return dataItem;
        }
    }
}
