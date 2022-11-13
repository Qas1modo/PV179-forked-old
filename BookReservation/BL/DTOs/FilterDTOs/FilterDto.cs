using System.Linq.Expressions;

namespace BL.DTOs.FilterDTOs
{
    public abstract class FilterDto
    {
        // Default values ?? but have them defined in one place --> magical constants
        public string? Predicate { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public string? SortCriteria { get; set; }
        public bool? Ascending { get; set; } // default true in ^
    }
}
