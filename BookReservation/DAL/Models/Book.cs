using System.ComponentModel.DataAnnotations;
using DAL.Enums;

namespace DAL.Models
{
    public class Book : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public Genre Genre { get; set; }

        // ErrorMessage = ""?
        [Range(0, int.MaxValue), Required]
        public int Stock { get; set; }

        [Range(0, int.MaxValue), Required]
        public int Total { get; set; }

        [Range(0, float.MaxValue), Required]
        public float Price { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public virtual List<Rent> Rents { get; set; }

        public virtual List<Review> Reviews { get; set; }

        public virtual List<CartItem> CartItems { get; set; }
    }
}
