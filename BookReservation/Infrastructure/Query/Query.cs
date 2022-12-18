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
        public List<(Expression expression, string columnName)> WherePredicates { get; set; } = new();

        public (string column, bool ascending, Type type)? OrderByData;

        public (string column, Type type)? SelectColumn { get; set; }

        public int? PageNumber { get; set; }

        public int PageSize = 20;

        public IQuery<TEntity> Page(int page, int pageSize)
        {
            PageNumber = page;
            PageSize = pageSize;
            return this;
        }

        public IQuery<TEntity> OrderBy<T>(string columnName, bool ascending = true) where T : IComparable<T>
        {
            OrderByData = (columnName, ascending, typeof(T));
            return this;
        }

        public IQuery<TEntity> Where<T>(Expression<Func<T, bool>> predicate, string columnName)
        {
            WherePredicates.Add((predicate, columnName));
            return this;
        }

        public abstract Task<QueryResult<TEntity>> Execute();
    }
}
