﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _0_Framework.Domain
{
    public interface IRepository<Tkey, T> where T : class
    {
        T Get(Tkey id);
        List<T> GetAll();
        void Create(T entity);
        bool Exists(Expression<Func<T,bool>> expression);
        void SaveChanges();
    }
}
