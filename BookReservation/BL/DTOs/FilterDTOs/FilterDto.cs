using System.Linq.Expressions;

namespace BL.DTOs.FilterDTOs
{
    public abstract class FilterDto
    {
        public string? Predicate { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public string? SortCriteria { get; set; }
        public bool? Ascending { get; set; }
    }
}
