using DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Rent : BaseEntity
    {
        public virtual User User { get; set; }

        public virtual Book Book { get; set; }

        public DateTime RentedAt { get; set; }

        [Range(1, 365)]
        public int LoanPeriod { get; set; }

        public decimal Price { get; set; }

        public RentState State { get; set; }
    }
}
