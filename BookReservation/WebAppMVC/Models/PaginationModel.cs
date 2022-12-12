using DAL.Enums;

namespace WebAppMVC.Models
{
    public class PaginationModel<TEntity>
    {
        public int PageNumber { get; set; }
        public bool NextPageEmpty { get; set; }
        public RentState CurrentState { get; set; }
        public string Group { get; set; }
        public int UserId { get; set; }
        public IEnumerable<TEntity> Items { get; set; }
    }
}
