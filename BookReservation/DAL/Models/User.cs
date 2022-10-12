using DAL.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class User : BaseEntity
    {

        [MaxLength(64), Required]
        public string Name { get; set; }

        [ForeignKey(nameof(AddressId))]
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Salt { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
        
        [Required]
        public Group Group { get; set; }

        public string Picture { get; set; }

        public virtual List<Rent> Rents { get; set; }

        public virtual List<Review> Reviews { get; set; }

        public virtual List<CartItem> CartItems { get; set; }
    }
}
