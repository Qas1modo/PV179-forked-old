using System.Linq.Expressions;

namespace BL.DTOs.QueryObject.Filters
{
    public abstract class AbstractFilterDto<TEntity> where TEntity : class
    {
        // Default values ?? but have them defined in one place --> magical constants
        public int? RequestedPageNumber { get; set; }

        public int? PageSize { get; set; } // default 20 in query

        public bool? Ascending { get; set; } // default true in ^
    }
}
