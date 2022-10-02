using System.ComponentModel.DataAnnotations;
using DAL.Enums;

namespace DAL.Models
{
    public class Reservation : BaseEntity
    {
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        public DateTime ReservedAt { get; set; }

        [Range(1, 365)] // max one year
        public int Duration { get; set; }

        public ReservationState State { get; set; }  

    }
}
