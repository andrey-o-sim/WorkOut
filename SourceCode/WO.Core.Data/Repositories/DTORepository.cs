using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces.Repositories;
using WO.Core.DAL.Interfaces;
using WO.Core.DAL.Model;
using WO.Core.Data.Configs;

namespace WO.Core.Data.Repositories
{
    public class DTORepository<TData, TDto> : IRepositoryDTO<TDto> where TData : BaseModel where TDto : BaseModelDTO
    {
        private IRepository<TData> _repository;
        private IMapper _mapper;
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
            var itemForUpdate = _repository.Get(item.Id);

            _mapper.Map<TDto, TData>(item, itemForUpdate);
            itemForUpdate.ModifiedDate = DateTime.Now;

            _repository.Update(itemForUpdate);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public TDto Find(Func<TDto, bool> predicate)
        {
            var repPredicate = _mapper.Map<Func<TDto, bool>, Func<TData, bool>>(predicate);
            var result = _repository.Find(repPredicate);
            var dataItems = _mapper.Map<TDto>(result);

            return dataItems;
        }

        public IEnumerable<TDto> FindMany(Func<TDto, bool> predicate)
        {
            var repPredicate = _mapper.Map<Func<TDto, bool>, Func<TData, bool>>(predicate);
            var result = _repository.FindMany(repPredicate).ToList();
            var dataItems = _mapper.Map<List<TDto>>(result);

            return dataItems;
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
            var dataItems = _mapper.Map<List<TDto>>(dbItem);
            return dataItems;
        }
    }
}
