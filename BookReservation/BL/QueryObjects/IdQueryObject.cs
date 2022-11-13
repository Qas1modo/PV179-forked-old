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
    }
}
