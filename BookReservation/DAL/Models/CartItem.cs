using Castle.Components.DictionaryAdapter;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class CartItem : BaseEntity
    {
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        public virtual Book Book { get; set; }

        [Required]
        public int LoanPeriod { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }
    }
}
