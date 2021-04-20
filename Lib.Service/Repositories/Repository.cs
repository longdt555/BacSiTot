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
        internal DbSet<T> DbSet;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public Repository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public T Get(object id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IEnumerable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            // Include properties will be comma separated
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
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

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            // Include properties will be comma separated
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperties);
                }
            }

            return query.FirstOrDefault();
        }
        public void Update(T entity)
        {
            DbSet.Update(entity);
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
