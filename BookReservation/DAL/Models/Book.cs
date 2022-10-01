using System.ComponentModel.DataAnnotations;
using DAL.Enums;

namespace DAL.Models
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public Genre Genre { get; set; }

        // ErrorMessage = ""?
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public virtual List<Rent> Rents { get; set; }

        public virtual List<Reservation> Reservations { get; set; }

        public virtual List<ReservationItem> ReservationItems { get; set; }
    }
}
