namespace DAL.Models
{
    public class ReservationItem : BaseEntity
    {
        public virtual User User { get; set; }

        public virtual Book Book { get; set; }

    }
}
