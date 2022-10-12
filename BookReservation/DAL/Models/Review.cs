using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Review : BaseEntity
    {
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey(nameof(BookId))]
        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        [Range(1, 10), Required]
        public int Score { get; set; }

        public virtual List<ReviewPoint> ReviewPoints { get; set; }
    }
}
