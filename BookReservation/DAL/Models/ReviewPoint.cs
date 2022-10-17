using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class ReviewPoint : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int ReviewId { get; set; }

        [ForeignKey(nameof(ReviewId))]
        public virtual Review Review { get; set; }

        [MaxLength(150), Required]
        public string Text { get; set; }

        [Required]
        public bool Positive {get; set; }
        public string TableName { get; } = nameof(BookReservationDbContext.ReviewPoints);
    }
}
