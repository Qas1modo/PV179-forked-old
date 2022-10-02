using DAL.Enums;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace DAL.Models
{
    public class Rent : BaseEntity
    {
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public virtual Book Book { get; set; }

        [Required]
        public DateTime ReservedAt { get; set; }

        [Required]
        public DateTime? RentedAt { get; set; }

        [Required]
        public DateTime? ReturnedAt { get; set; }

        [Range(1, 365), Required]
        public int LoanPeriod { get; set; }

        [Range(0, float.MaxValue), Required]
        public float Price { get; set; }

        [Required]
        public RentState State { get; set; }
    }
}
