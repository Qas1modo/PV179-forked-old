using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class ReviewPoint : BaseEntity
    {
        [ForeignKey(nameof(ReviewId))]
        public int ReviewId { get; set; }

        public virtual Review Review { get; set; }

        [MaxLength(150), Required]
        public string Text { get; set; }

        [Required]
        public bool Positive {get; set; }
    }
}
