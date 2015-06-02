using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Abstract
{
    public abstract class Repository<T> : IRepository<T>
         where T : class
    {
        private amadbContext _entities = null;

        public Repository()
        {
            _entities = new amadbContext();
        }

        public IQueryable<T> GetEntities(Expression<Func<T, bool>> predicate = null)
        {
            IQueryable<T> query = null;

            if (predicate == null)
            {
                query = _entities.Set<T>();
            }
            else
            {
                query = _entities.Set<T>().Where(predicate);
            }

            return query;
        }

        public void Insert(T entity)
        {
            _entities.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _entities.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_entities != null)
                {
                    _entities.Dispose();
                    _entities = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
