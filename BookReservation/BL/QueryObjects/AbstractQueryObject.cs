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

        public IQuery<TEntity> ApplyOrderBy(AbstractFilterDto<TEntity> abstractFilterDto)
        {
            if (abstractFilterDto.OrderByCriteria != null)
            {

                return _query.OrderBy(abstractFilterDto.OrderByCriteria, abstractFilterDto.Ascending);
            }

            return _query;
        }

        public IQuery<TEntity> ApplyPagination(AbstractFilterDto<TEntity> abstractFilterDto)
        {
            if (abstractFilterDto.RequestedPageNumber != null)
            {
                return _query.Page(abstractFilterDto.RequestedPageNumber, abstractFilterDto.PageSize);
            }

            return _query;
        }

    }
}
