using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class NegativeReview : BaseEntity
    {
        public int ReviewId { get; set; }

        public virtual Review Review { get; set; }

        [MaxLength(150), Required]
        public string Text { get; set; }
    }
}
