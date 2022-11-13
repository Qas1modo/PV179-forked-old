using AutoMapper;
using BL.DTOs.QueryObjects;
using BL.DTOs.QueryObjects.Filters;
using DAL.Models;
using Infrastructure.Query;

namespace BL.QueryObjects
{
    public class IdQueryObject<TEntity, TDto> : AbstractQueryObject<TEntity, TDto> where TEntity : BaseEntity, new()
    {

        private IMapper mapper;

        private IQuery<TEntity> query;

        public IdQueryObject(IMapper mapper, IQuery<TEntity> query)
        {
            this.mapper = mapper;
            this.query = query;
        }

        public QueryResultDto<TDto> ExecuteQuery(IdFilterDto filter)
        {

            var q = query.Where<string>(a => a.Id == filter.Id);

            q = ApplyOrderBy(q);
            q = ApplyPagination(q);

            return mapper.Map<QueryResultDto<TDto>>(q.Execute());
        }

    }
}
