using AutoMapper;
using BL.DTOs.FilterDTOs;
using BL.DTOs.QueryObjects;
using DAL.Models;
using Infrastructure.Query;

namespace BL.QueryObjects
{
    public class IdQueryObject<TEntity, TDto> where TEntity : BaseEntity, new()
    {
        private readonly IMapper mapper;

        private IQuery<TEntity> _query;

        public IdQueryObject(IMapper mapper, IQuery<TEntity> query)
        {
            this.mapper = mapper;
            _query = query;
        }
        public QueryResultDto<TDto> ExecuteQuery(FilterDto filter)
        {
            var query = _query.Where<string>(a => a == filter.Predicate, "Id");
            if (filter.SortCriteria is not null)
            {
                query = query.OrderBy<int>(filter.SortCriteria, filter.Ascending ?? true);
            }
            if (filter.PageNumber is not null)
            {
                query = query.Page(filter.PageNumber.Value, filter.PageSize ?? 20);
            }

            return mapper.Map<EFQueryResult<TEntity>, QueryResultDto<TDto>>(query.Execute());
        }
    }
}
