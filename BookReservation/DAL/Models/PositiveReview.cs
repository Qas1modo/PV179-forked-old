using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class PositiveReview : BaseEntity
    {
        public virtual Review Review { get; set; }

        [MaxLength(150)]
        public string Text { get; set; }
    }
}
