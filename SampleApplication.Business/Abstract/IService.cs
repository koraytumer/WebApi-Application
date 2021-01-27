﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SampleApplication.Business.Abstract
{
    public interface IService<T> where T : class
    {
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetList(Expression<Func<T, bool>> filter = null);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
