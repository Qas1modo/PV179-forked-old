using DAL.Models;
using BL.DTOs.QueryObject.Filters;
using Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.QueryObjects
{
    // TDto necessart ?
    public abstract class AbstractQueryObject<TEntity, TDto> where TEntity : BaseEntity, new()
    {
        protected IQuery<TEntity> _query;
    }
}
