using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Lib.Repository.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lib.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        internal DbSet<T> dbSet;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="context"></param>
        public Repository(DbContext context)
        {
            Context = context;
            dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(object id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> fillter = null, Func<IEnumerable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (fillter != null)
            {
                query = query.Where(fillter);
            }
            // Include properties will be comma seperated
            if (includeProperties != null)
            {
                foreach (var inlcudeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperties);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> fillter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (fillter != null)
            {
                query = query.Where(fillter);
            }
            // Include properties will be comma seperated
            if (includeProperties != null)
            {
                foreach (var inlcudeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperties);
                }
            }

            return query.FirstOrDefault();
        }
        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
        //public void Remove(object id)
        //{
        //    T entity = dbSet.Find(id);
        //    Remove(entity);
        //}

        //public void Remove(T entity)
        //{
        //    dbSet.Remove(entity);
        //}
    }
}
