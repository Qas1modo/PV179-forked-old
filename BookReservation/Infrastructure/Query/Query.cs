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
        public List<(Expression expression, Type argumentType, string columnName)> WherePredicate { get; set; } = new();
        public (string tableName, bool isAscending, Type argumentType)? OrderByContainer { get; set; }
        public (int PageToFetch, int PageSize)? PaginationContainer { get; set; }
        public IQuery<TEntity> Page(int pageToFetch, int pageSize = 20)
        {
            PaginationContainer = (pageToFetch, pageSize);
            return this;
        }

        public IQuery<TEntity> OrderBy<T>(string columnName, bool ascendingOrder = true) where T : IComparable<T>
        {
            OrderByContainer = (columnName, ascendingOrder, typeof(T));
            return this;
        }

        public IQuery<TEntity> Where<T>(Expression<Func<T, bool>> predicate, string columnName) where T : IComparable<T>
        {
            WherePredicate.Add((predicate, typeof(T), columnName));
            return this;
        }

        public abstract IEnumerable<TEntity> Execute();
    }
}
