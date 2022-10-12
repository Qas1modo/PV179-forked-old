using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class CartItem : BaseEntity
    {
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey(nameof(BookId))]
        public int BookId { get; set; }

        public virtual Book Book { get; set; }

    }
}
