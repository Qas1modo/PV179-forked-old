using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Address : BaseEntity
    {
        public virtual User User { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public int StNumber { get; set; }
        
        [Required]
        public int ZipCode { get; set; }
    }
}
