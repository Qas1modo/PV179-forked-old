using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Enums;

namespace DAL.Models
{
    public class Book : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public virtual Author Author { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public virtual Genre Genre { get; set; }

        public int GenreId { get; set; }

        // ErrorMessage = ""?
        [Range(0, int.MaxValue), Required]
        public int Stock { get; set; }

        [Range(0, int.MaxValue), Required]
        public int Total { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public virtual List<Rent> Rents { get; set; }

        public virtual List<Review> Reviews { get; set; }

        public virtual List<CartItem> CartItems { get; set; }
    }
}
