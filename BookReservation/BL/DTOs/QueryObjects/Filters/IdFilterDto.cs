using BL.DTOs.QueryObject.Filters;

namespace BL.DTOs.QueryObjects.Filters
{
    public class IdFilterDto<TEntity> : AbstractFilterDto<TEntity> where TEntity : class
    {
        public int Id { get; set; }
    }
}
