using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Address : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public virtual User User { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public int StNumber { get; set; }
        
        [Required]
        public int ZipCode { get; set; }

        [NotMapped]
        public string TableName { get; } = nameof(BookReservationDbContext.Addresses);
    }
}
