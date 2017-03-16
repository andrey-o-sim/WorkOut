﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.Core.DAL.Model;

namespace WO.Core.DAL.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Find(Func<T, bool> predicate);
        IEnumerable<T> FindMany(Func<T, bool> predicate);
        int Create(T item);
        void Update(T item);
        void Delete(int id);
        void AttachToContext<TEntity>(TEntity item) where TEntity : class;
    }
}
