﻿using Microsoft.EntityFrameworkCore;
using SampleApplication.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SampleApplication.DataAccess.Concrete.EntityFramework
{
    public class EfGenericRepository<T, TContext> : IRepository<T>
        where T : class
        where TContext : NorthwindContext, new()
    {
        public void Add(T entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().SingleOrDefault(filter);
            }
        }

        public List<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<T>().ToList()
                    : context.Set<T>().Where(filter).ToList();
            }
        }

        public void Update(T entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
