using DAL.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace DAL.Models
{
    public class Rent : BaseEntity
    {
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey(nameof(BookId))]
        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        [Required]
        public DateTime ReservedAt { get; set; }

        public DateTime? RentedAt { get; set; }

        public DateTime? ReturnedAt { get; set; }

        [Range(1, 365), Required]
        public int LoanPeriod { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public RentState State { get; set; }
    }
}
