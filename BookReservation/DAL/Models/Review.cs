using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Review : BaseEntity
    {
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        [Range(1, 10), Required]
        public int Score { get; set; }

        public virtual List<PositiveReview> PositiveReviews { get; set; }

        public virtual List<NegativeReview> NegativeReviews { get; set; }
    }
}
