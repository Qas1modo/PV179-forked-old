using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class NegativeReview : BaseEntity
    {
        public virtual Review Review { get; set; }

        [MaxLength(150)]
        public string Text { get; set; }
    }
}
