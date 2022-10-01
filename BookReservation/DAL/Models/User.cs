using DAL.Enums;
using System.ComponentModel.DataAnnotations;


namespace DAL.Models
{
    public class User : BaseEntity
    {

        [MaxLength(64)]
        public string Name { get; set; }

        public virtual Address Address { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string? Phone { get; set; }


        public DateTime BirthDate { get; set; }

        public Group Group { get; set; }

        public string Picture { get; set; }

        public virtual List<Rent> Rents { get; set; }

        public virtual List<Reservation> Reservations { get; set; }

        public virtual List<ReservationItem> ReservationItems { get; set; }


    }
}
