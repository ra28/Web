using SchoolApp.Server.Models;
using SchoolApp.Server.Models.DataObject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SchoolApp.Server.IRepository
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly BookServiceContext _dbContext;

        public Repository()
        {
            _dbContext = new BookServiceContext();
        }

        public virtual void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>()
                   .Where(predicate)
                   .AsEnumerable();
        }

        public virtual void Edit(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll()
        {
           return _dbContext.Set<T>().AsEnumerable();
        }

        public virtual T GetByID(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }
    }
}