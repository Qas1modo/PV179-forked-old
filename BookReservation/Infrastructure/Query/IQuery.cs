using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Query
{
    public interface IQuery<TEntity> where TEntity : BaseEntity, new() 
    {
        Query<TEntity> Where<T>(Expression<Func<TEntity, bool>> rootPredicate) where T : IComparable<T>;
        Query<TEntity> OrderBy<T>(Expression<Func<TEntity, T>> selector, bool ascending = true) where T : IComparable<T>;
        Query<TEntity> Page(int page, int pageSize = 20);
        IEnumerable<TEntity> Execute();
    }
}
