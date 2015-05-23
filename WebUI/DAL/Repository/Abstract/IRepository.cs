using System;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repository.Abstract
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetEntities(Expression<Func<T, bool>> predicate = null);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Save();
    }
}
