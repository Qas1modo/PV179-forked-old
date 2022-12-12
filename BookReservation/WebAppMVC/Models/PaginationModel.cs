using DAL.Enums;

namespace WebAppMVC.Models
{
    public class PaginationModel<TEntity>
    {
        public int PageNumber { get; set; }
        public bool NextPageEmpty { get; set; }
        public RentState CurrentState { get; set; }
        public IEnumerable<TEntity> Items { get; set; }
    }
}
