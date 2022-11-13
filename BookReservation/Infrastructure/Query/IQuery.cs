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
        IQuery<TEntity> Where<T>(Expression<Func<T, bool>> rootPredicate, string columnName) where T : IComparable<T>;
        IQuery<TEntity> OrderBy<T>(string columnName, bool ascending = true) where T : IComparable<T>;
        IQuery<TEntity> Page(int page, int pageSize = 20);
        IEnumerable<TEntity> Execute();
    }
}
