﻿using System;
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
        protected IRepository<TData> _repository;
        protected IMapper _mapper;
        protected IUnitOfWork _unitOfWork;

        public DTORepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.GetGenericRepository<TData>();
            _mapper = AutoMapperDataConfiguration.MapperConfiguration.CreateMapper();
        }

        public virtual int Create(TDto item)
        {
            var dbItem = _mapper.Map<TData>(item);
            dbItem.CreatedDate = DateTime.Now;
            dbItem.ModifiedDate = DateTime.Now;

            _repository.Create(dbItem);
            _unitOfWork.Commit();

            return dbItem.Id;
        }

        public virtual ICollection<TDto> CreateMany(ICollection<TDto> items)
        {
            var dbItems = _mapper.Map<List<TData>>(items);

            foreach (TData item in dbItems)
            {
                item.CreatedDate = DateTime.Now;
                item.ModifiedDate = DateTime.Now;

                _repository.Create(item);
            }
            _unitOfWork.Commit();

            var result = _mapper.Map<List<TDto>>(dbItems);

            return result;
        }

        public virtual void Update(TDto item)
        {
            var itemForUpdate = _repository.Get(item.Id);

            _mapper.Map<TDto, TData>(item, itemForUpdate);
            itemForUpdate.ModifiedDate = DateTime.Now;

            _repository.Update(itemForUpdate);
            _unitOfWork.Commit();
        }

        public virtual void Delete(int id)
        {
            var itemForRemove = _repository.Get(id);
            _repository.Delete(itemForRemove);
            _unitOfWork.Commit();
        }

        public virtual TDto Find(Func<TDto, bool> predicate)
        {
            var repPredicate = _mapper.Map<Func<TDto, bool>, Func<TData, bool>>(predicate);

            var result = _repository.Find(repPredicate);

            var dataItems = _mapper.Map<TDto>(result);

            return dataItems;
        }

        public virtual IEnumerable<TDto> FindMany(Func<TDto, bool> predicate)
        {
            var repPredicate = _mapper.Map<Func<TDto, bool>, Func<TData, bool>>(predicate);

            var result = _repository.FindMany(repPredicate).ToList();

            var dataItems = _mapper.Map<List<TDto>>(result);

            return dataItems;
        }

        public virtual TDto Get(int id)
        {
            var dbItem = _repository.Get(id);

            var dataItem = _mapper.Map<TDto>(dbItem);
            return dataItem;
        }

        public virtual IEnumerable<TDto> GetAll()
        {
            var dbItems = _repository.GetAll();

            var dataItems = _mapper.Map<List<TDto>>(dbItems);
            return dataItems;
        }
    }
}
