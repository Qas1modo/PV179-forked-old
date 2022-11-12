using DAL.Models;
using Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Query
{
    public abstract class Query<TEntity> : IQuery<TEntity> where TEntity : BaseEntity, new()
    {
        protected IQueryable<TEntity> query;

        public IQuery<TEntity> Page(int page, int pageSize = 20)
        {
            query = query.Skip((page -1) * pageSize).Take(pageSize);
            return this;
        }

        public IQuery<TEntity> OrderBy<T>(Expression<Func<TEntity, T>> selector, bool ascending = true) where T : IComparable<T>
        {
            query = ascending ? query.OrderBy(selector) : query.OrderByDescending(selector);
            return this;
        }

        public IQuery<TEntity> Where<T>(Expression<Func<TEntity, bool>> predicate) where T : IComparable<T>
        {
            query = query.Where(predicate);
            return this;
        }

        public abstract IEnumerable<TEntity> Execute();
    }
}
